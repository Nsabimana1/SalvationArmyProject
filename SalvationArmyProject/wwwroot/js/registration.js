// JavaScript source code


var event = {
    'summary': 'Red Kettle',
    'description': 'This is an event to help raise some money.'
    'start': {
        'dateTime': '2019-12-19T12:00:00-02:00',
        'timeZone': 'America/Arkansas'
    },
    'attendees': [
        {'email': 'william.harris108@gmail.com'}
    ]
}

var request = gapi.client.calendar.events.insert({
    'calendarId': 'primary',
    'resource': event
});

request.execute(function (event) {
    appendPre('Event created: ' + event.htmlLink);
});