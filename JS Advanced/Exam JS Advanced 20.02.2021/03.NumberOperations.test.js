const numberOperations = require('./03.NumberOperations');
let {expect, assert} = require('chai');

describe('powNumber', ()=>{
    it('should ', function () {
        assert.equal(numberOperations.powNumber(2),4)
    });
});

describe('numberChecker', ()=>{
    it('should <100', function () {
        assert.equal(numberOperations.numberChecker(1), 'The number is lower than 100!');
    });
    it('should >=100', function () {
        assert.equal(numberOperations.numberChecker(101), 'The number is greater or equal to 100!');
        assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
    });
    it('should throw error', function () {
        let badFunc = () => {numberOperations.numberChecker('a')};
        expect(badFunc).to.throw('The input is not a number!');
    });
});

describe('sumArrays', ()=>{
    it('should return correct array', function () {
        assert.deepEqual(numberOperations.sumArrays([1,2],[1,2]),[2,4]);
        assert.deepEqual(numberOperations.sumArrays([1,2,3],[1,2]),[2,4,3]);
        assert.deepEqual(numberOperations.sumArrays([1,2],[1,2,3]),[2,4,3]);
    });
})