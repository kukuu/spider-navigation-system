class Spider {
    constructor(x, y, orientation, gridWidth, gridHeight) {
        this.x = x;
        this.y = y;
        this.orientation = orientation;
        this.gridWidth = gridWidth;
        this.gridHeight = gridHeight;
        this.path = [{ x, y, orientation }];
    }

    turnLeft() {
        const turns = { 'Up': 'Left', 'Left': 'Down', 'Down': 'Right', 'Right': 'Up' };
        this.orientation = turns[this.orientation];
        this.path.push({ x: this.x, y: this.y, orientation: this.orientation });
    }

    turnRight() {
        const turns = { 'Up': 'Right', 'Right': 'Down', 'Down': 'Left', 'Left': 'Up' };
        this.orientation = turns[this.orientation];
        this.path.push({ x: this.x, y: this.y, orientation: this.orientation });
    }

    moveForward() {
        switch (this.orientation) {
            case 'Up':
                if (this.y < this.gridHeight) this.y += 1;
                break;
            case 'Right':
                if (this.x < this.gridWidth) this.x += 1;
                break;
            case 'Down':
                if (this.y > 0) this.y -= 1;
                break;
            case 'Left':
                if (this.x > 0) this.x -= 1;
                break;
        }
        this.path.push({ x: this.x, y: this.y, orientation: this.orientation });
    }

    executeInstructions(instructions) {
        for (const instruction of instructions) {
            switch (instruction) {
                case 'L':
                    this.turnLeft();
                    break;
                case 'R':
                    this.turnRight();
                    break;
                case 'F':
                    this.moveForward();
                    break;
                default:
                    console.warn(`Unknown instruction: ${instruction}`);
            }
        }
    }

    getFinalPosition() {
        return `${this.x} ${this.y} ${this.orientation}`;
    }
}

module.exports = { Spider };