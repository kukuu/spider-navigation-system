class Visualizer {
    static displayPath(path, gridWidth, gridHeight) {
        console.log('\n🕸️  NAVIGATION PATH VISUALIZATION:\n');
        
        // Create grid
        const grid = [];
        for (let y = 0; y <= gridHeight; y++) {
            const row = [];
            for (let x = 0; x <= gridWidth; x++) {
                row.push('·');
            }
            grid.push(row);
        }
        
        // Mark path
        path.forEach((step, index) => {
            const symbol = this.getDirectionSymbol(step.orientation);
            grid[step.y][step.x] = index === path.length - 1 ? '★' : symbol;
        });
        
        // Display grid (inverted Y-axis for proper visualization)
        for (let y = grid.length - 1; y >= 0; y--) {
            let row = '';
            for (let x = 0; x < grid[y].length; x++) {
                row += grid[y][x] + ' ';
            }
            console.log(row);
        }
        
        console.log('\n📈 PATH STEPS:');
        path.forEach((step, index) => {
            console.log(`Step ${index}: (${step.x}, ${step.y}) facing ${step.orientation}`);
        });
    }
    
    static getDirectionSymbol(orientation) {
        const symbols = { 'Up': '↑', 'Right': '→', 'Down': '↓', 'Left': '←' };
        return symbols[orientation] || '·';
    }
}

module.exports = { Visualizer };