window.onload = function () {//onload pt ca am getElementById care cere DOM
    
    var marker;
    var myLocation;
    var x=0;
    var map;
    var computeButton = document.getElementById('computeRoute');
    var locationCircle;
    var testLayer = new L.LayerGroup()

    function getPosition(myLocation){
        navigator.geolocation.getCurrentPosition((position) => {
        console.log(position);
        var distance=getDistanceRad([position.coords.latitude, position.coords.longitude], [44.43857823331789,  26.070835590362552]); 

       if(x==1)
            { 
                marker.remove(marker);
                try {
                    testLayer.removeLayer(marker);
                    testLayer.removeLayer(marker.circle);
                } catch (error) {
                    console.log("error when deleting group")
                }
                
                console.log("The customLoc marker deleted");
            }
       x=1;

       marker = L.marker([position.coords.latitude, position.coords.longitude]).addTo(testLayer)
         .bindPopup(`Distance between my current location and the AutoShop: about  ${distance} kilometers`)
         .openPopup();

       locationCircle= new L.circle([position.coords.latitude, position.coords.longitude], {
           // console.console.log("circle opened");
            radius: position.coords.accuracy,
            color: 'Orange',
            fillColor: 'yellow',
            fillOpacity: '0.2'
        }).addTo(testLayer).bindPopup("I live somewhere in this area");    //.openPopup();

        marker.circle=locationCircle;
        map.addLayer(testLayer);

    })  
    }

    function getDistanceRad(origin, destination) {
        // return distance in meters
        var lon1 = toRadian(origin[1]),
        lat1 = toRadian(origin[0]),
        lon2 = toRadian(destination[1]),
         lat2 = toRadian(destination[0]);
    
        var deltaLat = lat2 - lat1;
        var deltaLon = lon2 - lon1;
    
        var a = Math.pow(Math.sin(deltaLat/2), 2) + Math.cos(lat1) * Math.cos(lat2) * Math.pow(Math.sin(deltaLon/2), 2);
        var c = 2 * Math.asin(Math.sqrt(a));
        var EARTH_RADIUS = 6371;
        return c * EARTH_RADIUS;
    }

    function toRadian(degree) {
        return degree*Math.PI/180;
    }
    

    function getDistance(from, to) {
        return (from.distanceTo(to)).toFixed(0) / 1000; //m in km
        console.log(from);
        console.log(to);
    }

    function mapReady() {
        map = L.map('map').setView([44.43857823331789, 26.070835590362552], 7);
        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1,
            accessToken: 'pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw'
        }).addTo(map);  //asta imi afiseaza mapa

        myLocation = L.marker([44.43857823331789,  26.070835590362552]).addTo(map);     //asta imi afiseaza marker
        //x=0;

        map.addEventListener('click', (e) => {
            console.log(e);
            var distance = getDistance(e.latlng, myLocation.getLatLng());   //parametrii obiecte
            console.log("e.latlng", e.latlng);
        
            if(x==1)
               {
                    marker.remove();
                    //map.removeLayer(location)
                    try {
                        testLayer.removeLayer(marker);
                        testLayer.removeLayer(marker.circle);
                    } catch (error) {
                        console.log("error when deleting group")
                    };
               }

            x=1;
            marker = L.marker([e.latlng.lat, e.latlng.lng]).addTo(map)
                .bindPopup(`Distance between my position and the AutoShop: ${distance} kilometers`)
                .openPopup();
        })
       
        // function createIcon(type) {
        computeButton.addEventListener('click', () => {
            getPosition(myLocation);

        });

        // function compare(p1, p2)
    }

    mapReady()

}