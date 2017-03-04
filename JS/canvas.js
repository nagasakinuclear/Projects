// <canvas id="canvas" width="500" height="500"></canvas> 

class TimeCanvas{ 
	constructor( canvas,color,bgColor){ 
		this.canvas = document.getElementById("canvas"); 
		this.lineColor= color; 
		this.bgColor= bgColor; 
		this.ctx=this.canvas.getContext('2d'); 
		this.ctx.strokeStyle= this.lineColor 
		this.ctx.lineWidth=17; 
		this.ctx.lineCap='round'; 
		this.ctx.shadowBlur=15; 
		this.ctx.shadowColor='#28d1fa'; 

} 
	rad(deg){ 
		var factor = Math.PI/180; 
		return deg*factor; 
	} 
	time(){ 

	let now = new Date(),
		 totay = now.toDateString(),
		 time = now.toLocaleDateString(),
		 hours = now.getHours(),
		 minutes = now.getMinutes(),
		 seconds = now.getSeconds(),
		 milliseconds = now.getMilliseconds(),
		 newSeconds = seconds+(milliseconds/1000);

	//background 
			this.ctx.fillStyle = this.bgColor; 
			this.ctx.fillRect(0,0,500,500); 

			//hours 
			this.ctx.beginPath(); 
			this.ctx.arc(250,250,200, this.rad(270), this.rad((hours*31)-90)); 
			this.ctx.stroke(); 

			//minutes 
			this.ctx.beginPath(); 
			this.ctx.arc(250,250,150, this.rad(270), this.rad((minutes*6)-90)); 
			this.ctx.stroke(); 
			//seconds 
			this.ctx.beginPath(); 
			this.ctx.arc(250,250,100, this.rad(270), this.rad((seconds*6)-90)); 
			this.ctx.stroke(); 
			this.ctx.beginPath(); 

			this.ctx.fillStyle = "white"; 
			this.ctx.font= "25px _sansl"; 
			if(seconds<10) 
			seconds="0"+seconds; 

			if(minutes<10) 
			minutes="0"+minutes; 

			if(hours<10) 
			hours="0"+hours; 

			this.ctx.fillText(hours+":"+minutes+":"+seconds, 205, 255); 
			this.ctx.stroke(); 
	} 
} 
var aa = new TimeCanvas(canvas,"lightblue","darkblue"); 
setInterval(function(){ 
aa.time(); 
}, 1000) 

