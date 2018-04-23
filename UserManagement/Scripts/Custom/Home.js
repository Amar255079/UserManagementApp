$("#CountryID").change(function () {
    $("#Country").val($("#CountryID :selected").text());
    CountryChange();
});

$("#StateID").change(function () {
    $("#State").val($("#StateID :selected").text());
    StateChange();
});

$("#CityID").change(function () {
    $("#City").val($("#CityID :selected").text());
});



function AddProgress(controls) {
    $(controls).each(function (index, control) {
        $("#" + control).addClass('loading');
    });
}

function RemoveProgress(controls) {
    $(controls).each(function (index, control) {
        $("#" + control).removeClass('loading');
    });
}

function ChangeStateToInitial(controls) {
    $(controls).each(function (index, control) {
        var ControlName = control.substring(0, control.length - 2);
        $("#" + control).empty();
        $("#" + control).append($("<option selected=true></option>").val('0').html('--Select ' + ControlName + '--'));
    });
}

function CountryChange() {
    ChangeStateToInitial(['StateID', 'CityID']);
    var selectedCountryID = $("#CountryID").val();
    if (selectedCountryID == 0) {
        return;
    }
    AddProgress(['CountryID', 'StateID']);
    $.ajax({
        url: "/home/StaticStates?countryID=" + selectedCountryID,
        success: function (result) {
            $.each(result, function () {
                $("#StateID").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        }, error: function (data) {
            RemoveProgress(['CountryID', 'StateID']);
        }
    }).done(function () {
        RemoveProgress(['CountryID', 'StateID']);
    });
}

function StateChange() {
    ChangeStateToInitial(['CityID']);
    var selectedStateID = $("#StateID").val();
    if (selectedStateID == 0) {
        return;
    }
    AddProgress(['StateID', 'CityID']);
    $.ajax({
        url: "/home/StaticCities?stateID=" + selectedStateID,
        success: function (result) {
            $.each(result, function () {
                $("#CityID").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        }, error: function (data) {
            RemoveProgress(['StateID', 'CityID']);
        }
    }).done(function () {
        RemoveProgress(['StateID', 'CityID']);
    });;
}