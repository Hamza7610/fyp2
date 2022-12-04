window.onload = function()
{
    $('.detailsform').submit(function(e)
    {
        if($('.idad_name').val().trim() == '')
        {            
            swal.fire('Name is required');
            e.preventDefault();
            return false;
        }        
        return true;
    });
    $('.passwordform').submit(function(e)
    {
        if($('.oldP').val().trim() == '')
        {            
            swal.fire('Old password is required');
            e.preventDefault();
            return false;
        }
        if($('.newP').val().trim() == '')
        {            
            swal.fire('New password is required');
            e.preventDefault();
            return false;
        }
        if($('.rnewP').val().trim() == '')
        {            
            swal.fire('Re-type New password is required');
            e.preventDefault();
            return false;
        }
        if($('.newP').val() != $('.rnewP').val())
        {            
            swal.fire('Passwords dont match');
            e.preventDefault();
            return false;
        }
        return true;
    });
}