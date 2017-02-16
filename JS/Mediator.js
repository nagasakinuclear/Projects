(function () {//Decorator encapsulates the relationship of objects

    function object1(params) {
        this.value1 = params.value1;
        this.value2 = params.value2;
    }
    object1.prototype = {
        get1: function () {
            return this.value1;
        },
        get2: function () {
            return this.value2;
        }
    }

    function object2() {
        this.value1;
    }
    object2.prototype = {
        manipulate: function () {
            this.value2 = Mediator.tryToGetValues1() + Mediator.tryToGetValues2();
        }
    }

    var Mediator = {
        object1: new object1,
        object2: new object2,
        tryToGetValues1: function () {
            this.object1.get1();
        },
        tryToGetValues2: function () {
            this.object1.get2();
        }
    }
})();