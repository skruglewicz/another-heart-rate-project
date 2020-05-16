#pragma once

#include "mt3620_avnet_dev.h"

#ifndef _OLEDHAL_H_
#define _OLEDHAL_H_

#define T_HAL_P         const uint8_t* 

/*
// These are for OLED-C in mikroBUS #1
#define OLEDC_GPIO_AN	AVT_SK_CM1_AN
#define OLEDC_GPIO_RST	AVT_SK_CM1_RST
#define OLEDC_GPIO_PWM	AVT_SK_CM1_PWM
#define OLEDC_GPIO_INT	AVT_SK_CM1_INT
#define OLEDC_SPI_CS	MT3620_SPI_CHIP_SELECT_A
*/

// These are for OLED-C in mikroBUS #2
#define OLEDC_GPIO_AN	AVT_SK_CM2_AN
#define OLEDC_GPIO_RST	AVT_SK_CM2_RST
#define OLEDC_GPIO_PWM	AVT_SK_CM2_PWM
//#define OLEDC_GPIO_INT	AVT_SK_CM2_INT
#define OLEDC_GPIO_INT	AVT_SK_CM1_RX
#define OLEDC_SPI_CS	MT3620_SPI_CHIP_SELECT_B

void Delay_1ms(void);
void Delay_100ms(void);
void hal_gpioMap(T_HAL_P spiObj);
void hal_spiMap(T_HAL_P spiObj);
void hal_spiWrite(uint8_t* pBuf, uint16_t nBytes);
void hal_gpio_rstSet(int value);
void hal_gpio_pwmSet(int value);
void hal_gpio_intSet(int value);
void hal_gpio_csSet(int value);

#endif