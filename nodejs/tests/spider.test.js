const { Spider } = require('../src/models/Spider.js');
const { InputParser } = require('../src/utils/InputParser.js');
const { NavigationService } = require('../src/services/NavigationService.js');

describe('Spider Navigation', () => {
    test('should parse input correctly', () => {
        const wallSize = InputParser.parseWallSize('7 15');
        expect(wallSize.width).toBe(7);
        expect(wallSize.height).toBe(15);
        
        const spiderPos = InputParser.parseSpiderPosition('4 10 Left');
        expect(spiderPos.x).toBe(4);
        expect(spiderPos.y).toBe(10);
        expect(spiderPos.orientation).toBe('Left');
        
        const instructions = InputParser.parseInstructions('FLFLFRFFLF');
        expect(instructions).toEqual(['F','L','F','L','F','R','F','F','L','F']);
    });
    
    test('should navigate correctly with example input', () => {
        const wallSize = { width: 7, height: 15 };
        const spiderPosition = { x: 4, y: 10, orientation: 'Left' };
        const instructions = ['F','L','F','L','F','R','F','F','L','F'];
        
        const spider = NavigationService.navigate(wallSize, spiderPosition, instructions);
        
        expect(spider.getFinalPosition()).toBe('5 7 Right');
    });
    
    test('spider should turn correctly', () => {
        const spider = new Spider(0, 0, 'Up', 5, 5);
        
        spider.turnRight();
        expect(spider.orientation).toBe('Right');
        
        spider.turnLeft();
        expect(spider.orientation).toBe('Up');
    });
    
    test('spider should move correctly', () => {
        const spider = new Spider(2, 2, 'Up', 5, 5);
        
        spider.moveForward();
        expect(spider.y).toBe(3);
        
        spider.turnRight();
        spider.moveForward();
        expect(spider.x).toBe(3);
    });
});