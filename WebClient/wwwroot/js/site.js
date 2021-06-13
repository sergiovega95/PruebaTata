
$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});


document.getElementById("btnsend").addEventListener("click", SearchWord);


function ValidForm()
{
    let pattern = document.getElementById("textword").value;
    let text = document.getElementById("textarea").value;
    let isValid = true;

    if (!pattern.trim().length > 0)
    {
        document.getElementById("labeltext").innerText = "Ingrese un parametro de búsqueda"
        document.getElementById("labeltext").style.display = 'block';
        isValid = false;
    }
    else
    {      
        document.getElementById("labeltext").style.display = 'none';
    }

    if (!text.trim().length > 0)
    {
        document.getElementById("labeltextarea").innerText = "Ingrese el texto de búsqueda"
        document.getElementById("labeltextarea").style.display = 'block';
        isValid = false;
    }
    else
    {
       
        document.getElementById("labeltextarea").style.display = 'none';
    }

    return isValid;
}

async function SearchWord()
{
    try
    {
        let isValid = ValidForm();
        var pattern = document.getElementById("textword").value;
        var text = document.getElementById("textarea").value;

        if (isValid)
        {
            var request =
            {
                Pattern: pattern,
                Text: text
            }

            var response = await $.ajax({
                method: "POST",
                url: "?handler=SearchWord",
                data: request
            })

            if (response!=null)
            {
                document.getElementById("response").style.display = 'block';
                document.getElementById("response").innerHTML = `<div>Resultado</div> <div>Palabra: ${pattern}</div> <div>N° Apariciones: ${response.totalCount}</div>`
            }

        }

    }
    catch (error)
    {
        Swal.fire(
            'Error',
            `${error}`,
            'error'
        )
    }   
}

