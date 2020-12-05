function ClientBaseMyCountry() {
    $.ajax({
        url: 'http://demo.ip-api.com/json/?fields=66842623&lang=en',
        dataType: 'json',
        type: "GET",
        success: function (data) {
            $("#clientBaseCountryInfo").html(data.country);
            SpeakingLanguages(data.country,"SpeakingLanguages");
        },
        error: function () {
            $("#clientBaseCountryInfo").html("Turkey");
            SpeakingLanguages("Turkey","SpeakingLanguages");
        }
    })
}

function SpeakingLanguages(country,element) {
    $.ajax({
        url: '/api/Sorgu/Language?searchText='+country,
        dataType: 'json',
        type: "GET",
        success: function (data) {
            $("#" + element + "").html(data);
        },
        error: function () {
            if (navigator.onLine) {
                $("#" + element + "").html("Bulunamadı!");
            }
            else {
                $("#" + element + "").html("Greek (modern), Turkish, Armenian");
            }
        }
    })
}
