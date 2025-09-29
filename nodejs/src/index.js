const { InputParser } = require('./utils/InputParser.js');
const { NavigationService } = require('./services/NavigationService.js');
const { Visualizer } = require('./utils/Visualizer.js');

class SpiderNavigationApp {
    static run() {
        console.log('🕷️  SPIDER NAVIGATION SYSTEM\n');
        
        // Test input from the requirement
        const wallInput = "7 15";
        const spiderInput = "4 10 Left";
        const instructionsInput = "FLFLFRFFLF";
        
        console.log('Input:');
        console.log(`Wall: ${wallInput}`);
        console.log(`Spider: ${spiderInput}`);
        console.log(`Instructions: ${instructionsInput}\n`);
        
        try {
            const wallSize = InputParser.parseWallSize(wallInput);
            const spiderPosition = InputParser.parseSpiderPosition(spiderInput);
            const instructions = InputParser.parseInstructions(instructionsInput);
            
            const spider = NavigationService.navigate(wallSize, spiderPosition, instructions);
            
            console.log('📊 FINAL RESULT:');
            console.log(`Expected: 5 7 Right`);
            console.log(`Actual: ${spider.getFinalPosition()}`);
            
            // Visualization
            Visualizer.displayPath(spider.path, wallSize.width, wallSize.height);
            
        } catch (error) {
            console.error('❌ Error:', error.message);
        }
    }
}

// Run the application
SpiderNavigationApp.run();