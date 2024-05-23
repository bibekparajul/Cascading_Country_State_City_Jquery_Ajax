$(document).ready(function () {
    $('#country').attr('disabled', true);
    $('#states').attr('disabled', true);
    $('#city').attr('disabled', true);
    LoadCountries();
    $('#country').change(function () {
        var countryId = $(this).val();
        if (countryId > 0) {
            LoadStates(countryId);
        }
        else {
            alert("Select Country");
            $('#states').empty();
            $('#city').empty();
            $('#states').attr('disabled', true);
            $('#city').attr('disabled', true);
            $('#states').append('<option>--Select State--</option>');
            $('#city').append('<option>--Select City--</option>');
        }
    });

    $('#states').change(function () {
        var statesId = $(this).val();
        if (statesId > 0) {
            LoadCities(statesId);
        }
        else {
            alert("Select State");
            $('#city').empty();

            $('#city').attr('disabled', true);
            $('#city').append('<option>--Select City--</option>');
        }
    });

});

function LoadCountries() {
    $('#country').empty();

    $.ajax({
        url: '/Cascading/GetCountries',
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#country').attr('disabled', false);
                $('#country').append('<option>--Select Country--</option>');
                $('#states').append('<option>--Select State--</option>');
                $('#city').append('<option>--Select City--</option>');
                $.each(response, function (i, data) {
                    $('#country').append('<option value=' + data.countryId + '>' + data.countryName + '</option>');

                });
            }
            else {
                $('#country').attr('disabled', true);
                $('#states').attr('disabled', true);
                $('#city').attr('disabled', true);
                $('#country').append('<option>-- Country not avai--</option>');
                $('#states').append('<option>-- State not avai--</option>');
                $('#city').append('<option>--city not avai--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

function LoadStates(countryId) {
    $('#states').empty();
    $('#city').empty();
    $('#city').attr('disabled', true);


    $.ajax({
        url: '/Cascading/GetStates?Id=' + countryId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#states').attr('disabled', false);
                $('#states').append('<option>--Select State--</option>');
                $('#city').append('<option>--Select City--</option>');
                $.each(response, function (i, data) {
                    $('#states').append('<option value=' + data.stateId + '>' + data.stateName + '</option>');

                });
            }
            else {
                $('#states').attr('disabled', true);
                $('#city').attr('disabled', true);
                $('#states').append('<option>-- State not avai--</option>');
                $('#city').append('<option>--city not avai--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}


function LoadCities(statesId) {
    $('#city').empty();


    $.ajax({
        url: '/Cascading/GetCities?id=' + statesId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#city').attr('disabled', false);
                $('#city').append('<option>--Select City--</option>');
                $.each(response, function (i, data) {
                    $('#city').append('<option value=' + data.cityId + '>' + data.cityName + '</option>');

                });
            }
            else {
                $('#city').attr('disabled', true);
                $('#city').append('<option>--city not avai--</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}