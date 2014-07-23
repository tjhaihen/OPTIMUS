var Methods = new (function () {
    this.getListObject = function (methodName, filterExpression, functionHandler) {
        $.ajax({
            // have to use synchronous here, else returns before data is fetched
            async: false,
            type: 'POST',
            url: ResolveUrl('~/Libs/Service/MethodService.asmx/GetListObject'),
            contentType: 'application/json; charset=utf-8',
            data: '{ "methodName" : "' + methodName + '", "filterExpression" : "' + filterExpression + '"}',
            dataType: 'json',
            error: function (msg) {
                alert(msg.responseText);
            },
            success: function (msg) {
                functionHandler(msg.d);
            }
        });     //end ajax
    };

    this.getObject = function (methodName, filterExpression, functionHandler) {
        $.ajax({
            // have to use synchronous here, else returns before data is fetched
            async: false,
            type: 'POST',
            url: ResolveUrl('~/Libs/Service/MethodService.asmx/GetObject'),
            contentType: 'application/json; charset=utf-8',
            data: '{ "methodName" : "' + methodName + '", "filterExpression" : "' + filterExpression + '"}',
            dataType: 'json',
            error: function (msg) {
                alert(msg.responseText);
            },
            success: function (msg) {
                functionHandler(msg.d);
            }
        });     //end ajax
    };

    this.getObjectValue = function (methodName, filterExpression, returnField, functionHandler, $row) {
        $.ajax({
            // have to use synchronous here, else returns before data is fetched
            async: false,
            type: 'POST',
            url: ResolveUrl('~/Libs/Service/MethodService.asmx/GetObjectValue'),
            contentType: 'application/json; charset=utf-8',
            data: '{ "methodName" : "' + methodName + '", "filterExpression" : "' + filterExpression + '", "returnField" : "' + returnField + '"}',
            dataType: 'json',
            error: function (msg) {
                alert(msg.responseText);
            },
            success: function (msg) {
                if ($row != null)
                    window[functionHandler]($row, msg.d);
                else
                    window[functionHandler](msg.d);
            }
        });     //end ajax
    };

    this.getObjectValueFromSession = function (sessionName, filterBy, filterValue, returnField, functionHandler, $row) {
        $.ajax({
            // have to use synchronous here, else returns before data is fetched
            async: false,
            type: 'POST',
            url: ResolveUrl('~/Libs/Service/MethodService.asmx/GetObjectValueFromSession'),
            contentType: 'application/json; charset=utf-8',
            data: '{ "sessionName" : "' + sessionName + '", "filterBy" : "' + filterBy + '", "filterValue" : "' + filterValue + '", "returnField" : "' + returnField + '"}',
            dataType: 'json',
            error: function (msg) {
                alert(msg.responseText);
            },
            success: function (msg) {
                //alert(msg.d);
                if ($row != null)
                    window[functionHandler]($row, msg.d);
                else
                    window[functionHandler](msg.d);
            }
        });     //end ajax
    };

    this.getObjectFromSession = function (sessionName, filterBy, filterValue, functionHandler, $row) {
        $.ajax({
            // have to use synchronous here, else returns before data is fetched
            async: false,
            type: 'POST',
            url: ResolveUrl('~/Libs/Service/MethodService.asmx/GetObjectFromSession'),
            contentType: 'application/json; charset=utf-8',
            data: '{ "sessionName" : "' + sessionName + '", "filterBy" : "' + filterBy + '", "filterValue" : "' + filterValue + '"}',
            dataType: 'json',
            error: function (msg) {
                alert(msg.responseText);
            },
            success: function (msg) {
                //alert(msg.d);
                if ($row != null)
                    window[functionHandler]($row, msg.d);
                else
                    window[functionHandler](msg.d);
            }
        });     //end ajax
    };

    this.getDateFromJSON = function (jsonDate) {
        return new Date(parseInt(jsonDate.substr(6)));
    };

    this.dateToYMD = function (date) {
        var d = date.getDate();
        var m = date.getMonth() + 1;
        var y = date.getFullYear();
        return '' + y + '-' + (m <= 9 ? '0' + m : m) + '-' + (d <= 9 ? '0' + d : d);
    }

    this.stringToDate = function (value) {
        if (value != '') {
            var YYYY = value.substring(0, 4);
            var MM = value.substring(4, 6);
            var DD = value.substring(6);
            var date = new Date(parseInt(YYYY, 10), parseInt(MM, 10) - 1, parseInt(DD, 10));
            return date;
        }
        return new Date();
    }
    this.stringToDateTime = function (value) {
        if (value != '') {
            var YYYY = value.substring(0, 4);
            var MM = value.substring(4, 6);
            var DD = value.substring(6, 8);
            var HH = value.substring(8, 10);
            var mm = value.substring(10, 12);
            var date = new Date(parseInt(YYYY, 10), parseInt(MM, 10) - 1, parseInt(DD, 10), parseInt(HH, 10), parseInt(mm, 10));
            return date;
        }
        return new Date();
    }
    this.dateToString = function (value) {
        var dateStr = padStr(value.getFullYear()) +
                  padStr(1 + value.getMonth()) +
                  padStr(value.getDate());
        return dateStr;
    }

    function padStr(i) {
        return (i < 10) ? "0" + i : "" + i;
    }


    this.ExecuteFunction = function (fn, s) {
        fn(s);
    }

    this.daysInMonth = function (month, year) {
        return new Date(year, month, 0).getDate();
    }

    this.calculateDateDifference = function (d1, d2) {
        var years, months, days = 0;

        days = d2.getDate() - d1.getDate();
        months = d2.getMonth() - d1.getMonth();
        years = d2.getFullYear() - d1.getFullYear();
        if (d2.getMonth() < d1.getMonth()) {
            years--;
            months += 12;
        }
        if (d2.getDate() < d1.getDate()) {
            months--;
            if (d2.getMonth() > 0)
                days += new Date(d2.getFullYear(), d2.getMonth(), 0).getDate();
            else
                days += new Date(d2.getFullYear() - 1, 12, 0).getDate();
        }
        return { "years": years, "months": months, "days": days };
    }

    this.checkImageError = function (className, type, classGender) {
        setTimeout(function () {
            var imgUrlM = ResolveUrl("~/Images/male.JPG");
            var imgUrlF = ResolveUrl("~/Images/female.JPG");
            $('.' + className).each(function () {
                if (!this.complete || typeof this.naturalWidth == "undefined" || this.naturalWidth == 0) {
                    // image was broken, replace with your new image
                    var gender = $(this).parent().find('.' + classGender).val();
                    if (gender == 'F')
                        this.src = imgUrlF;
                    else
                        this.src = imgUrlM;
                }
            });
        }, 100);
    }

})();

(function ($) {
    $.fn.rptTemplate = function (idInputHdn, clickHandler) {
        var id = this[0].id;
        $('#' + idInputHdn).val('');
        $('#' + id + ' .repeaterDataItemTemplate').live('click', function () {
            $(this).parent().children().attr('class', 'repeaterDataItemTemplate notSelected');
            $(this).attr('class', 'repeaterDataItemTemplate selected');

            var idValue = $(this).find('.repeaterDataItemID').val();
            $('#' + idInputHdn).val(idValue);
            if (clickHandler != null) {
                window[clickHandler](idValue);
            }
        });
    };
})(jQuery);