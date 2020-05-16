#include "stdint.h"
#include <time.h>
#include <errno.h>
#include <string.h>
#include "applibs_versions.h"
#include <applibs/log.h>
#include <applibs/spi.h>
#include <applibs/gpio.h>
#include <soc/mt3620_spis.h>

#include "oledc_hal.h"


const struct timespec timespec1ms = { 0, 1000000 };

void Delay_1ms() {
	nanosleep(&timespec1ms, NULL);
}

const struct timespec timespec100ms = { 0, 100000000 };

void Delay_100ms() {
	nanosleep(&timespec100ms, NULL);
}

int oledcAnFd = -1;
int oledcRstFd = -1;
int oledcPwmFd = -1;
int oledcIntFd = -1;

void hal_gpioMap(T_HAL_P spiObj) {

	// AN is actually R/W and is left low for write. We never read.
	oledcAnFd = GPIO_OpenAsOutput(OLEDC_GPIO_AN, GPIO_OutputMode_PushPull, GPIO_Value_Low);
	if (oledcAnFd == -1) {
		Log_Debug("Error opening GPIO: %s (%d).\n", strerror(errno), errno);
		return -1;
	}

	// Reset (0 = reset, 1 = normal)
	oledcRstFd = GPIO_OpenAsOutput(OLEDC_GPIO_RST, GPIO_OutputMode_PushPull, GPIO_Value_High);
	if (oledcRstFd == -1) {
		Log_Debug("Error opening GPIO: %s (%d).\n", strerror(errno), errno);
		return -1;
	}

	// PWM is really D/C (0 = Command, 1 = Data)
	oledcPwmFd = GPIO_OpenAsOutput(OLEDC_GPIO_PWM, GPIO_OutputMode_PushPull, GPIO_Value_High);
	if (oledcPwmFd == -1) {
		Log_Debug("Error opening GPIO: %s (%d).\n", strerror(errno), errno);
		return -1;
	}

	// INT is really enable (0 = disabled, 1 = enabled)
	oledcIntFd = GPIO_OpenAsOutput(OLEDC_GPIO_INT, GPIO_OutputMode_PushPull, GPIO_Value_High);
	if (oledcIntFd == -1) {
		Log_Debug("Error opening GPIO: %s (%d).\n", strerror(errno), errno);
		return -1;
	}

	return 0;
}

static int spiFd = -1;

void hal_spiMap(T_HAL_P spiObj) {

	SPIMaster_Config config;
	int ret = SPIMaster_InitConfig(&config);
	if (ret != 0) {
		Log_Debug("ERROR: SPIMaster_InitConfig = %d errno = %s (%d)\n", ret, strerror(errno),
			errno);
		return -1;
	}
	config.csPolarity = SPI_ChipSelectPolarity_ActiveLow;
	spiFd = SPIMaster_Open(MT3620_SPI_ISU1, OLEDC_SPI_CS, &config);
	if (spiFd < 0) {
		Log_Debug("ERROR: SPIMaster_Open: errno=%d (%s)\n", errno, strerror(errno));
		return -1;
	}

	int result = SPIMaster_SetBusSpeed(spiFd, 400000);
	if (result != 0) {
		Log_Debug("ERROR: SPIMaster_SetBusSpeed: errno=%d (%s)\n", errno, strerror(errno));
		return -1;
	}

	result = SPIMaster_SetMode(spiFd, SPI_Mode_0);
	if (result != 0) {
		Log_Debug("ERROR: SPIMaster_SetMode: errno=%d (%s)\n", errno, strerror(errno));
		return -1;
	}
}

void hal_spiWrite(uint8_t* pBuf, uint16_t nBytes) {

	SPIMaster_Transfer transfer;
	ssize_t            transferredBytes;

	if (SPIMaster_InitTransfers(&transfer, 1) != 0)
		return -1;

	transfer.flags = SPI_TransferFlags_Write;
	transfer.writeData = pBuf;
	transfer.length = nBytes;

	transferredBytes = SPIMaster_TransferSequential(spiFd, &transfer, 1);

	if (transferredBytes != transfer.length) {
		Log_Debug("ERROR: SPIMaster_TransferSequential expected %d bytes but transferred %d\n", transfer.length, transferredBytes);
	}
}

void hal_gpio_rstSet(int value) {
	GPIO_SetValue(oledcRstFd, value);
}

void hal_gpio_pwmSet(int value) {
	// This is really Data(1) / Command (0)
	GPIO_SetValue(oledcPwmFd, value);
}

void hal_gpio_intSet(int value) {
	GPIO_SetValue(oledcIntFd, value);
}

void hal_gpio_csSet(int value) {
	// Done automatically by SPI config
}