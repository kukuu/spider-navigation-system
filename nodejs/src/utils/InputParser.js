class InputParser {
    static parseWallSize(input) {
        const [width, height] = input.trim().split(' ').map(Number);
        return { width, height };
    }

    static parseSpiderPosition(input) {
        const parts = input.trim().split(' ');
        const x = parseInt(parts[0]);
        const y = parseInt(parts[1]);
        const orientation = parts[2];
        return { x, y, orientation };
    }

    static parseInstructions(input) {
        return input.trim().split('');
    }
}

module.exports = { InputParser };