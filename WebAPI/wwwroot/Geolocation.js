function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(returnPosition);
    }
}
function returnPosition(position) {
    DotNet.invokeMethod('WebClient', 'SetUserLocation', position.coords.latitude, position.coords.longitude);
}