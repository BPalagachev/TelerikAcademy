(function () {
    var center = new google.maps.LatLng(42.6544, 23.3649);
    var zoom = 4;

    var sofiaCoords = new google.maps.LatLng(42.6544, 23.3649);
    var parisCoods = new google.maps.LatLng(48.8742, 2.3470);
    var londonCoods = new google.maps.LatLng(51.5171, 0.1062);
    var warsawCoods = new google.maps.LatLng(52.2300, 21.0108);
    var lisbonCoods = new google.maps.LatLng(38.7000, 9.1833);
    var moscowCoors = new google.maps.LatLng(55.7517, 37.6178);
    var beijingCoors = new google.maps.LatLng(39.9100, 116.4000);
    var canberraCoors = new google.maps.LatLng(35.2828, 149.1314);
    var washingtonCoods = new google.maps.LatLng(38.8900, 77.0300);
    var mexicoCoods = new google.maps.LatLng(19.1300, 99.4000);

    var locations = [sofiaCoords, parisCoods, londonCoods, warsawCoods, lisbonCoods, moscowCoors, beijingCoors, canberraCoors, washingtonCoods, mexicoCoods];

    function initialize() {
        var mapOptions = {
            zoom: zoom,
            center: center,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById('map-canvas'),
            mapOptions);

        var sofiaInfo = new google.maps.InfoWindow({
            map: map,
            position: sofiaCoords,
            content: "It occupies a strategic position at the centre of the Balkan Peninsula"
        });

        var parisInfo = new google.maps.InfoWindow({
            map: map,
            position: parisCoods,
            content: "Paris is the capital and most populous city of France"
        });

        var londonInfo = new google.maps.InfoWindow({
            map: map,
            position: londonCoods,
            content: "London is the capital of England and the United Kingdom."
        });

        var warsawInfo = new google.maps.InfoWindow({
            map: map,
            position: warsawCoods,
            content: "Warsaw, known in Polish as Warszawa, is the capital and largest city of Poland."
        });

        var lisbonInfo = new google.maps.InfoWindow({
            map: map,
            position: lisbonCoods,
            content: "Lisbon is the capital city and largest city of Portugal with a population of 547,631 within its administrative limits on a land area of 84.8 km²."
        });

        var moskowInfo = new google.maps.InfoWindow({
            map: map,
            position: moscowCoors,
            content: "Moscow is the capital city and the most populous federal subject of Russia."
        });

        var beijingInfo = new google.maps.InfoWindow({
            map: map,
            position: beijingCoors,
            content: "Beijing, sometimes romanized as Peking, is the capital of the People's Republic of China and one of the most populous cities in the world."
        });
        
        var canberraInfo = new google.maps.InfoWindow({
            map: map,
            position: canberraCoors,
            content: "Canberra is the capital city of Australia."
        });

        var washingtonInfo = new google.maps.InfoWindow({
            map: map,
            position: washingtonCoods,
            content: "Washington, D.C., formally the District of Columbia and commonly referred to as Washington, 'the District', or simply D.C., is the capital of the United States."
        });

        var mexicoInfo = new google.maps.InfoWindow({
            map: map,
            position: mexicoCoods,
            content: "Washington, D.C., formally the District of Columbia and commonly referred to as Washington, 'the District', or simply D.C., is the capital of the United States."
        });

        map.panTo(sofiaCoords);
   }

    google.maps.event.addDomListener(window, 'load', initialize());
    
    var current = 0;

    document.getElementById("Sofia").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(sofiaCoords);
        current = 0;
    });

    document.getElementById("Paris").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(parisCoods);
        current = 1;
    });

    document.getElementById("London").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(londonCoods);
        current = 2;
    });

    document.getElementById("Warsaw").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(warsawCoods);
        current = 3;
    });

    document.getElementById("Lisbon").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(lisbonCoods);
        current = 4;
    });

    document.getElementById("Moskow").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(moscowCoors);
        current = 5;
    });

    document.getElementById("Beijing").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(beijingCoors);
        current = 6;
    });

    document.getElementById("Canberra").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(canberraCoors);
        current = 7;
    });

    document.getElementById("Washington").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(washingtonCoods);
        current = 8;
    });

    document.getElementById("Mexico").addEventListener("click", function (ev) {
        ev.preventDefault();
        map.panTo(mexicoCoods);
        current = 9;
    });

    document.getElementById("previous-button").addEventListener("click", function (ev) {
        ev.preventDefault();
        current--;
        if (current < 0) {
            current = locations.length - 1;
        }
        map.panTo(locations[current]);
    });

    document.getElementById("next-button").addEventListener("click", function(ev){
        ev.preventDefault();
        current++;
        if (current >= locations.length) {
            current = 0;
        }
        map.panTo(locations[current]);
    });
    
}())