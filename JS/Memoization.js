function calculation(x, y) {
    var key = x.toString() + "|" + y.toString();
    var result = 0;

    if (!calculation.memento[key]) {
        for (var i = 0; i < y; ++i) result += x;
        calculation.memento[key] = result;
    }
    return calculation.memento[key];
}

calculation.memento = {};
console.profile();
console.log('result:' + calculation(2, 100000000));
console.profileEnd();

console.profile();
console.log('result:' + calculation(2, 100000000));
console.profileEnd();

console.profile();
console.log('result:' + calculation(2, 10000000));
console.profileEnd();
/*
Profile1: 626.739ms
result:200000000
0.012ms
result:200000000
63.055ms result:20000000 // it saves time if function calles with same arguments 2 or more times
*/