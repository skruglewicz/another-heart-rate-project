#  Copyright (c) Microsoft Corporation. All rights reserved.
#  Licensed under the MIT License.

cmake_minimum_required (VERSION 3.8)
project (BPM C)

# Create executable
add_executable (${PROJECT_NAME} azure_iot_utilities.c main.c oledc_driver.c oledc_hal.c parson.c )
target_link_libraries (${PROJECT_NAME} applibs pthread gcc_s c azureiot)

# Add MakeImage post-build command
include (${AZURE_SPHERE_MAKE_IMAGE_FILE})
