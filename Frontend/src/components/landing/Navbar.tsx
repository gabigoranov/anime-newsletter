import Logo from "../Logo";

export default function Navbar() {
  return (
    <nav className="sticky bg-surface/80 backdrop-blur-xl w-full top-0 z-50">
      <div className="flex justify-between items-center w-full py-4 max-w-7xl mx-auto section-container">
        
        {/* Logo */}
        <Logo />

        {/* Desktop CTA Button */}
        <button className="hidden md:block bg-primary text-on-primary font-semibold text-label-md px-gutter py-sm rounded-full hover:scale-105 active:scale-95 transition-all shadow-md shadow-primary/20 duration-200">
          Get Started
        </button>

        {/* Mobile Menu Icon */}
        <button className="md:hidden text-primary" aria-label="Open menu">
          <span className="material-symbols-outlined text-3xl">menu</span>
        </button>
        
      </div>
    </nav>
  );
}