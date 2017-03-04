function Validation(){ 
this.Form = document.getElementsByTagName("form"); 
this.FName = document.getElementById("FName"); 
this.Name = document.getElementById("Name"); 
this.Phone = document.getElementById("phone"); 
this.Email = document.getElementById("e-mail"); 
this.Pas = document.getElementById("Pas"); 
this.SerialNum = document.getElementById("ID"); 
this.In = document.getElementById("In"); 
this.Radio = document.getElementById("input[type=radio]") ; 
this.Grad; 
} 


let Valid = new Validation(); 

function resetCss(elem){ 
elem.style.backgroundColor = "white"; 
}

function setRed(Temp){
	Temp.style.backgroundColor = 'red'; 
	setTimeout(resetCss(Temp),600);
	return false; 
}

function CheckSubmit(){ //Form-submit(Post method)
let Temp; 
let RegName= new RegExp("/^[A-Za-zА-яІЇ]{2,20}/$"); 
let Passport= new RegExp("/^[(A-Za-zА-Яа-я{2})(0-9{4})]/$"); 
let email = new RegExp("/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/"); 
let pas = new RegExp( "^/[0-9A-Za-z{6,18}]$/"); 
let flag = true;

if(!RegName.test(Valid.FName.value)) 
{ 
	flag = false;
	setRed(Valid.FName);
} 
if(!RegName.test(Valid.Name.value)) 
{ 
	flag = false;
	setRed(Valid.Name);
} 
if(!Valid.Phone.length > 9) 
{ 
	flag = false;
	setRed(Valid.FName);
} 
if(!email.test(Valid.Emai.value)) 
{ 
	flag = false;
	setRed(Valid.Emai);
} 
if(!pas.check(Valid.Pas.value)) 
{ 
	flag = false;
	setRed(Valid.Pas); 
} 
if(!Passport.check(Valid.SerialNum.value)) 
{ 
	flag = false;
	setRed(Valid.SerialNum);
} 
if(!Valid.In.length == 10) //идентификационный номер
{ 
	flag = false;
	setRed(Valid.In);
} 

for(let elem in Valid.Radio) 
	elem == checked ? Valid.Grad = elem : elem; 

if(Valid.Grad == undefined) 
{ 
	flag = false;
	setRed(getElementByCId("graduation"));
} 

	return flag; 
} 