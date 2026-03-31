// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
    // 1. Staggered Cascade Load for Bento Cards
    // Targets all elements with your 'card-lift' class
    anime({
        targets: '.card-lift',
        translateY: [30, 0], // Start 30px down, move to original position
        opacity: [0, 1],     // Fade from invisible to fully visible
        delay: anime.stagger(100, {start: 100}), // 100ms delay between each card
        easing: 'easeOutExpo',
        duration: 1200
    });

    // 2. Subtle Pop for Action Buttons
    // Targets elements with your 'btn-kinetic' class
    anime({
        targets: '.btn-kinetic',
        scale: [0.9, 1],     // Start slightly shrunken, pop to full size
        opacity: [0, 1],
        delay: anime.stagger(150, {start: 600}), // Wait for cards to mostly load first
        easing: 'spring(1, 80, 10, 0)'
    });
});
