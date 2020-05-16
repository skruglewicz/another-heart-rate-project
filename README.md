# Sensing Myself

This multi-project solution is contains the code for a project entry in Element14's Sensing the World Challenge.

## Azure Sphere
The Azure Sphere project is designed to run on an Avnet Azure Sphere Starter Kit. It expects to find a Click Heart Rate 4 board in mikroBUS socket #1. This takes regular heart rate and oxygen saturation measurements and sends these via Azure IoT Hub to Azure Time Series Insights.

## Windows Application
The windows application continuously monitors Heart Rate and Oxygen Saturation that is stored in Azure Time Series Insights. It allows the user to view a summary of the current day's data and will request a reading if one has not been taken in the last 2 hours.

## More information
You will find more information on the project blog page on Element14.
https://www.element14.com/community/groups/azuresphere/blog/2019/10/04/sensing-the-world-sensing-myself