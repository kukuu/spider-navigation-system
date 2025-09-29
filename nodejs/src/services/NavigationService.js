import { Spider } from '../models/Spider.js';

export class NavigationService {
    static navigate(wallSize, spiderPosition, instructions) {
        const spider = new Spider(
            spiderPosition.x,
            spiderPosition.y,
            spiderPosition.orientation,
            wallSize.width,
            wallSize.height
        );
        
        spider.executeInstructions(instructions);
        return spider;
    }
}