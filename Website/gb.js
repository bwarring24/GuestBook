function Expand() {
    $(".gb_navbar_min").slideToggle();
}

function loadSum() {

}

// function myMap(d = 0) {
//     var pointX;
//     var pointY;
//     switch (d) {
//         case 0:
//             pointX = 41.152404;
//             pointY = -81.358359;
//             document.getElementById("sum").innerHTML = "<h2>Campus Book Store</h2><p>The Campus Book Store Is Just on campus with all the Supplies needed for a student to succed in classes</p>";
//             break;
//         case 1:
//             pointX = 41.152404;
//             pointY = -81.300000;
//             document.getElementById("sum").innerHTML = "<h2>Campus T</h2><p>Ever needed the perfect T-shirt? They have your covered!</p>";
//             break;
//     }
//     var myCenter = new google.maps.LatLng(pointX, pointY);
//     var mapCanvas = document.getElementById("map");
//     var mapOptions = { center: myCenter, zoom: 14 };
//     var map = new google.maps.Map(mapCanvas, mapOptions);
//     var marker = new google.maps.Marker({ position: myCenter });
//     marker.setMap(map);


// }
var map;
var marker;

function initMap() {
    var kent = new google.maps.LatLng(41.152404, -81.358359);

    var map = new google.maps.Map(document.getElementById("map"), {
        center: kent,
        zoom: 16,
        scrollwheel: false
    });

    // Specify location, radius and place types
    // for your Places API search.
    var request = {
        location: kent,
        radius: '500',
        types: ['food']
    };

    // Create the PlaceService and send the request.
    // Handle the callback with an anonymous function.
    var service = new google.maps.places.PlacesService(map);
    service.nearbySearch(request, function(results, status) {
        if (status == google.maps.places.PlacesServiceStatus.OK) {
            for (var i = 0; i < results.length; i++) {
                var place = results[i];
                // If the request succeeds, draw the place location on
                // the map as a marker, and register an event to handle a
                // click on the marker.
                marker = new google.maps.Marker({
                    map: map,
                    position: place.geometry.location,

                });
                var request = { placeId: place.place_id };
                service.getDetails(request, function(details, status) {
                    document.getElementById("place-name").innerHTML += "<div onclick=open() class='col-sm-12 label label-info'>" + details.name + "</div>"
                    document.getElementById("place-name").innerHTML += "<p>" + details.formatted_address + "</p>";
                    document.getElementById("place-name").innerHTML += "<p>" + details.formatted_phone_number + "</p>";
                });

            }
        } else {
            alert("error");
        }
    });


}

function open() {
    // alert("in");
    // marker = new google.maps.Marker({
    //     map: map,
    //     ]

    // });

}



// Run the initialize function when the window has finished loading.