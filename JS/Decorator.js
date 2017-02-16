
(function () {
    function Objects(value1,value2) {
        this.value1 = value1;
        this.value2 = value2;
    }
    Objects.prototype = {
        constructor: Objects,
        doSomething: function () {
            return "base class " + this.value1 + " , " + this.value2 ;
        }
    }

    function Decorator1(obj) {
        this.obj = obj;
    }
    Decorator1.prototype = {
        constructor: Decorator1,
        doSomething: function () {
            return this.obj.doSomething() + " modificated in Decorator1 ";
        }
    }

    function Decorator2(obj) {
        this.obj = obj;
    }
    Decorator2.prototype = {
        constructor: Decorator1,
        doSomething: function () {
            return this.obj.doSomething() + " modificated in Decorator2 ";
        }
    }

    let ModObject = new (Decorator2(new Decorator1(new Objects(42, 42))));
    
    console.log(ModObject.doSomething()); //base class 42 , 42 modificated in Decorator1 modificated in Decorator2
})();