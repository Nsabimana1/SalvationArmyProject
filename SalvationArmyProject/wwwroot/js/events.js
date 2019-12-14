var events = [
  {'Date': new Date(2019, 12, 7), 'Title': 'Red Kettle, 10:00-12:00'},
];
//use ajax to bring in the events
var settings = {};
var element = document.getElementById('caleandar');
console.log(element);
caleandar(element, events, settings);
