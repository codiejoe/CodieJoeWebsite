const sidebar = document.getElementById("sidebar");
const mobileMenu = document.getElementById("mobileMenu");

mobileMenu.addEventListener("click", () => {
    sidebar.classList.toggle("open");
});


const navItems = document.querySelectorAll(".nav-item");

navItems.forEach(item => {

    item.addEventListener("click", () => {
        navItems.forEach(nav => {
            nav.classList.remove("active");
        });
        item.classList.add("active");

    });

});