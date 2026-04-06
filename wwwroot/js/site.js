document.addEventListener('DOMContentLoaded', () => {
    // Staggered Cascade Load for Bento Cards
    anime({
        targets: '.card-lift',
        translateY: [30, 0],
        opacity: [0, 1],
        delay: anime.stagger(100, {start: 100}),
        easing: 'easeOutExpo',
        duration: 1200
    });

    // Subtle scale animation for primary buttons on load
    anime({
        targets: '.btn-kinetic',
        scale: [0.9, 1],
        opacity: [0, 1],
        delay: anime.stagger(150, {start: 600}),
        easing: 'spring(1, 80, 10, 0)'
    });
});
