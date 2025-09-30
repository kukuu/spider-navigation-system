const readline = require('readline');
const { Spider } = require('./models/Spider'); // FIX: Destructure Spider
const { InputParser } = require('./utils/InputParser');

class SpiderNavigationApp {
    constructor() {
        this.rl = readline.createInterface({
            input: process.stdin,
            output: process.stdout
        });
    }

    async run() {
        console.log('=== Spider Navigation System ===\n');

        try {
            // Get wall dimensions
            const dimensions = await this.question('Enter wall dimensions (format: "width height" e.g., "7 15"): ');
            const { width: gridWidth, height: gridHeight } = InputParser.parseWallSize(dimensions);

            // Get spider initial position
            const positionInput = await this.question('Enter spider initial position (format: "x y orientation" e.g., "4 10 Left"): ');
            const { x, y, orientation } = InputParser.parseSpiderPosition(positionInput);

            // Get instructions
            const instructionsInput = await this.question('Enter movement instructions (e.g., "FLEEREFLF"): ');
            const instructionsArray = InputParser.parseInstructions(instructionsInput);

            // Create spider with ALL required parameters
            const spider = new Spider(x, y, orientation, gridWidth, gridHeight);

            // Use spider's own executeInstructions method
            spider.executeInstructions(instructionsArray);

            // Get final position using spider's method
            const finalPosition = spider.getFinalPosition();

            // Display result
            console.log('\n=== Final Position ===');
            console.log(finalPosition);

        } catch (error) {
            console.error(`\nError: ${error.message}`);
        } finally {
            this.rl.close();
        }
    }

    question(prompt) {
        return new Promise((resolve) => {
            this.rl.question(prompt, resolve);
        });
    }
}

// Run the application if this file is executed directly
if (require.main === module) {
    const app = new SpiderNavigationApp();
    app.run();
}

module.exports = SpiderNavigationApp;