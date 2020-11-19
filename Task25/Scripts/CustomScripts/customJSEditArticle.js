function btnTegClick() {
    if (this.innerText == "-") {
        this.closest('li').remove()
    }
    else if (this.innerText == "+") {

        let countParn = this.closest('ul').children.length;

        var li = document.createElement('li');
        li.className = "input-group";
        li.setAttribute("id", `teg_${countParn+1}`);
        var div = document.createElement('div');
        div.className = "input-group";
        div.setAttribute("id", `teg_${countParn+1}`);
        var input = document.createElement('input');
        input.classList.add("form-control", "tegs", "text-box","single-line");
        //input.setAttribute("disabled", "disabled");
        input.setAttribute("id", `Tegs_${countParn}__Name`);
        input.setAttribute("name", `Tegs[${countParn}].Name`);
        input.setAttribute("type", "text");
        var span = document.createElement('span');
        span.className = "input-group-btn";
        var btn1 = document.createElement('button');
        btn1.className = "btn btn-default btn-teg";
        btn1.setAttribute("type", "button");
        btn1.innerText = "+";
        var btn2 = document.createElement('button');
        btn2.classList.add("btn", "btn-default", "btn-teg"); 
        btn2.setAttribute("type", "button");
        btn2.innerText = "-";
        li.appendChild(div);
        div.appendChild(input);
        div.appendChild(span);
        span.appendChild(btn1);
        span.appendChild(btn2);

        var br = document.createElement('br');
        li.appendChild(br);

        let elDis = this.closest('ul').children[countParn - 1].getElementsByTagName("input")[0];
        elDis.classList.add("inactive");

        this.closest('ul').appendChild(li);

        btn1.addEventListener("click", btnTegClick, false);
        btn2.addEventListener("click", btnTegClick, false);
    }

    
};

[...document.getElementsByClassName("btn-teg")].forEach(el => el.addEventListener("click", btnTegClick, false));

