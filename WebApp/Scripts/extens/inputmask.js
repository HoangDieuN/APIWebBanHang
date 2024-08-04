$.fn.allInputMask = () => {
    $.fn.dateInputMask();
    $.fn.yearInputMask();
    $.fn.timeInputMask();
}

$.fn.dateInputMask = () => {
    $(".date-inputmask").inputmask('dd/mm/yyyy', { 'placeholder': '__/__/____' });
}

$.fn.timeInputMask = () => {
    $(".time-inputmask").inputmask('hh:mm', { 'placeholder': '__:__' });
}

$.fn.yearInputMask = () => {
    $(".year-inputmask").inputmask('9999', { 'placeholder': '____' });
}