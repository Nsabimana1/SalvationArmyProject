var email = $('#email').text()
$(document).ready(function () {
    
    var location = 'https://localhost:5001/event/userApprovedEvents/' + email;
    console.log(location);
    $.ajax({
        type: 'GET',
        dataType: "json",
        url: 'https://localhost:44326/event/userApprovedEvents/' + $('#email').text(),
        success: function (results) {
            for (var a = 0; a < results.length; a++) {

                var i = results[a];

                if (i == null) {
                    continue;
                }

                var type = i['eventName'];
                var time = i['eventDateTime'];
                var dur = (i['eventDuration']);
                var desc = i['eventDescription'];
                var eventId = i['eventId'];

                modalDivs(time, a, eventId);


                var feed = `<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modal${a}"> Submit Feedback </button>`;
                var toAppend = '<tr><td>' + type + '</td><td>' + time + '</td><td>' + dur + ' hours</td><td>' + desc + '</td><td>' + feed + '</td></tr>';

                $('.table').append(toAppend);

            }
            function modalDivs(time, a, eventId) {

                var submit = $(`<button onclick="submitFeedback('${a}')" data-id="` + eventId + `" data-modal="${a}" id="submitter${a}" type="button" class="btn btn-primary">Submit</button>`);
                var modalFooter = $('<div class="modal-footer"></div>').append(submit);

                var input = $(`<textarea id="text${a}"class="form-control"></textarea>`)
                var formFor = $('<label></label>').append('name');
                var formGroup = $('<div class="form-group"></div>').append(formFor, input);
                var form = $('<form></form>').append(formGroup);
                var modalBody = $('<div class="modal-body"></div>').append(form);

                var modalTitle = $('<h4 class="modal-title"></h4>').text("Give us feed back on your experience for this event on " + time + " hours.");
                var times = $('<span aria-hidden="true"></span>').append('&times;');
                var closeButton = $('<button type="button" class="close" data-dismiss="modal" aria-label="Close"></button>').append(times);
                var modalHeader = $('<div class="modal-header"></div>').append(modalTitle, closeButton);

                var modalContent = $('<div class="modal-content"></div>').append(modalHeader, modalBody, modalFooter);
                var modalDialog = $(`<div class="modal-dialog modal-lg"></div>`).append(modalContent);
                var modal = $(`<div id="modal${a}" class="modal fade"></div>`).append(modalDialog);

                console.log($(`#modal${a}`));

                $('#mainTable').before(modal);
            }
        }
    });
    //$('#submitter').click(function () {
    //    console.log('hi');
    //    //$.ajax({
    //    //    url: 'https://localhost:5001/event/feedbackPost',
    //    //    type: 'post',
    //    //    data: {
    //    //        eventFK: 
    //    //    }

    //    //}):
    //});
    
});
function submitFeedback(textId) {
    var feedback = $(`#text${textId}`).val();
    var eventId = $(`#submitter${textId}`).attr('data-id');
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        accept: 'application/json',
        header: 'application/json',
        type: 'POST',
        url: "https://localhost:5001/event/feedbackPost",
        data: JSON.stringify({
            feedbackContent: feedback,
            eventFK: eventId,
            emailId: email,

        }),
        success: function (result) {
            console.log(result);
        },
        error: function (result) {
            console.log(result);
        }
    });

}