var events = [
  {'Date': new Date(2019, 12, 7), 'Title': 'Red Kettle, 10:00-12:00'},
];
//use ajax to bring in the events
var settings = {
    Color: '',
    LinkColor: '',
    NavShow: true,
    NavVertical: false,
    NavLocation: '',
    DateTimeShow: true,
    DateTimeFormat: 'mmm, yyyy',
    DatetimeLocation: '',
    EventClick: '',
    EventTargetWholeDay: true,
    DisabledDays: [],
    ModelChange: element
};
var element = document.getElementById('caleandar');
caleandar(element, events, settings);
