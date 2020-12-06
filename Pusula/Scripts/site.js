function ClientBaseMyCountry() {
    $.ajax({
        url: 'http://demo.ip-api.com/json/?fields=66842623&lang=en',
        dataType: 'json',
        type: "GET",
        success: function (data) {
            $("#clientBaseCountryInfo").html(data.country);
            SpeakingLanguages(data.country, "SpeakingLanguages");
        },
        error: function () {
            $("#clientBaseCountryInfo").html("Turkey");
            SpeakingLanguages("Turkey", "SpeakingLanguages");
        }
    })
}

function SpeakingLanguages(country, element) {
    $.ajax({
        url: '/api/Sorgu/Language?searchText=' + country,
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
                $("#" + element + "").html("Turkish");
            }
        }
    })
}

function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};

function FillCountries(page, take) {
    $.ajax({
        url: '/api/Sorgu/Countries?page=' + page + "&take=" + take,
        dataType: 'json',
        type: "GET",
        success: function (data) {
            var tmpl = $.templates("#Template"); 
            var html = tmpl.render(data.NumberedFilteredCountry);      
            $("#result").html(html);        
            var pages = "";
            var getUrl = window.location;
            var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];
            var url = baseUrl + "?id=";
            if (getUrlParameter("id") > 1 && getUrlParameter("id") != null) {
                pages += '<li class="page-item"><a class="page-link" href="' + url + (getUrlParameter("id") - 1) + '">' + "<<" + '</a></li>';
            }
            for (var i = 0; i < data.TotalPage; i++) {
                var pgs = i + 1;
                pages += '<li class="page-item"><a class="page-link" href="' + url + pgs + '">' + pgs + '</a></li>';
            }
            if (getUrlParameter("id") < data.TotalPage && getUrlParameter("id") != null) {
                pages += '<li class="page-item"><a class="page-link" href="' + url + (parseInt(getUrlParameter("id")) + 1) + '">' + ">>" + '</a></li>';
            }
            if (getUrlParameter("id") == null) {
                pages += '<li class="page-item"><a class="page-link" href="' + url + 1 + '">' + ">>" + '</a></li>';
            }
            $("#pages").html(pages);
        },
        error: function () {

        }
    })
}

function Slot(token) {
    if ($(".alt").html() != "0") {
        $.ajax({
            url: '/api/Sorgu/Slot?token=' + token,
            dataType: 'json',
            type: "GET",
            beforeSend: function () {
                $("#spnBtn").html("Lütfen Bekleyiniz");
            },
            success: function (data) {
                $(".imm li").css("background", "white");
                var first = data.Arr.split("-")[0] + ".jpg";
                var second = data.Arr.split("-")[1] + ".jpg";
                var third = data.Arr.split("-")[2] + ".jpg";
                $("#firstImg").attr("src", "/img/" + first);
                $("#secondImg").attr("src", "/img/" + second);
                $("#thirdImg").attr("src", "/img/" + third);
                $(".alt").html(data.Gold);
                $("#result").html("Durum: " + data.Prize + " altın kazandın.");
                $("#spnBtn").html("Spin");
            },
            error: function () {
            }
        })
    }
    else {
        $('.modal').modal('toggle');
    }
}