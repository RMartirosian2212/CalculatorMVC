document.addEventListener('DOMContentLoaded', function () {
    console.log("test");
    var form = document.querySelector('.calc');
    form.addEventListener('submit', function (e) {
        e.preventDefault();
    });
    var res_field = document.querySelector('.calc__result-field');
    var btn_num = document.querySelectorAll('.js--btn-add-res');
    var btn_reset = document.querySelector('.js--btn-reset');
    var btn_calc = document.querySelector('.js--btn-calc');

    var inputValues = '';
    var fullExpression = '';

    for (i = 0; i < btn_num.length; i++) {
        btn_num[i].addEventListener('click', function (e) {
            e.preventDefault();
            inputValues += this.innerHTML; 
            fullExpression += this.innerHTML;
            res_field.value = inputValues;
        });
    }

    btn_reset.addEventListener('click', function (e) {
        e.preventDefault();
        inputValues = '';
        fullExpression = '';
        res_field.value = '';
    });

    btn_calc.addEventListener('click', function (e) {
        e.preventDefault();
        if (fullExpression === '' || fullExpression === '=') {
            res_field.value = 'Empty expression';
            return;
        }
        try {
            var result = eval(fullExpression);
            inputValues = result;
            res_field.value = result;
            fullExpression += '=' + result;
            console.log('Full Expression:', fullExpression);

            sendExpressionToServer(fullExpression);

            fullExpression = result.toString();
        }
        catch (error) {
            res_field.value = 'Error';
            console.log('Calculation error:', error);
        }
    });
    function updateHistory() {
        $.ajax({
            type: "GET",
            url: "/Home/GetHistory",
            success: function (history) {
                var historyList = document.getElementById('history-list');
                historyList.innerHTML = '';
                history.forEach(function (operation) {
                    var listItem = document.createElement('li');
                    listItem.innerText = operation.mathExpression;
                    historyList.insertBefore(listItem, historyList.firstChild);
                });
            },
            error: function (error) {
                console.log('Error when retrieving transaction history:', error);
            }
        });
    }
    updateHistory();

    function sendExpressionToServer(expression) {
        $.ajax({
            type: "POST",
            url: "/Home/Index",
            data: { mathExpression: expression },
            success: function () {
                console.log('Data successfully sent to the server.');
                updateHistory(); 
            },
            error: function (error) {
                console.log('Error when sending data to the server:', error);
            }
        });
    }
});