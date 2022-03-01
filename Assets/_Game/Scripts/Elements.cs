enum Elements { Fire, Earth, Water, Air, Light, Dark, None }

static class ElementsMethods {
    public static Elements opposite(this Elements e) {
        switch (e) {
            case Elements.Fire:
                return Elements.Water;
            case Elements.Earth:
                return Elements.Air;
            case Elements.Water:
                return Elements.Fire;
            case Elements.Air:
                return Elements.Earth;
            case Elements.Light:
                return Elements.Dark;
            case Elements.Dark:
                return Elements.Light;
            default:
                return Elements.None;
        }
    }
}

