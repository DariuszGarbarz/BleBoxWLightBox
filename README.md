# WLightBoxApi

Reusable Class library that provides api communication with BleBox devices with API type: wLightBox. 
It can gather device status, it's state of lightning and uptime. On the other hand it can change device properties like color, effect and timings related to color and effect.

### CreateHttpClient()
Method used for httpclient creation. Can be extended in the future for authentication ect.
Returns ready to use httpclient for other methods.

### GetUptimeFromApi()
Gets uptime status of the device in seconds. Needs Device adress in string e.g. 192.168.1.11 and httpclient. Both need to be injected on it's class instance creation via constructor. 
Returns UptimeResponse.

### GetInfoFromApi()
Gets device status. Needs Device adress in string e.g. 192.168.1.11 and httpclient. Both need to be injected on it's class instance creation via constructor. 
Returns DeviceResponse.

### GetRgbwFromApi()
Gets device State of Lightning. Needs Device adress in string e.g. 192.168.1.11 and httpclient. Both need to be injected on it's class instance creation via constructor. 
Returns RgbwResponse.

### PostRgbwChangeColorToApi()
Post new color and colorFade settings to device. Needs Device adress in string e.g. 192.168.1.11, httpclient, desired color in 10-digit hex value e.g."ff00000000", color fade timing between 25 and 3600000 in integer  . All need to be injected on it's class instance creation via constructor. 
Returns RgbwResponse.

### PostRgbwChangeEffectToApi()
Post new effect, effectFade and effectStep settings to device. Needs Device adress in string e.g. 192.168.1.11, httpclient, effectId from 0 to 6 in integer, effect fade timing between 25 and 3600000 in integer, effect step timing between 25 and 3600000 in integer. All need to be injected on it's class instance creation via constructor. 
Returns RgbwResponse.



Api documentation for wLightBox:
https://app.swaggerhub.com/apis-docs/ela-compil/api-type_w_light_box/20200518#/General

wLightBox manual:
https://drive.google.com/file/d/1dn4KJH5gwMm92BL6zs-VajQTjiwL3YvA/view

# ElaCompilBleBox
Simple WPF app for BleBox devices currently compatible with wLightBox v3.
Together with WLightBoxApi class library it can show device status and current State of Lightning of the device.
It has build in controls for color and effect settings of the device.

# WLightBoxApiTest
Unit tests based on a Postman mock server. It is testing api communication via httpclient, json serialising and json deserialising.




