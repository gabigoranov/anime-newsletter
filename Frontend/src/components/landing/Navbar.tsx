import { LucideMail } from "lucide-react";

const navLinks = [
  { name: 'Features', href: '#features', active: true },
  { name: 'Updates', href: '#updates', active: false },
  { name: 'Pricing', href: '#pricing', active: false },
  { name: 'Integration', href: '#integration', active: false },
];

export default function Navbar() {
  return (
    <nav className="sticky bg-surface/80 backdrop-blur-xl w-full top-0 z-50">
      <div className="flex justify-between items-center w-full py-4 max-w-7xl mx-auto section-container">
        
        {/* Logo */}
        <div className="flex items-center gap-sm cursor-pointer hover:text-secondary transition-colors">
          <LucideMail className="text-primary" />
          <span className="font-display text-xl text-primary font-semibold tracking-tight">
            Ani Mail 
          </span>
        </div>

        {/* Navigation Links */}
        <ul className="hidden md:flex gap-md items-center">
          {navLinks.map((link) => (
            <li key={link.name}>
              <a
                href={link.href}
                className={`font-body-md text-body-md transition-colors hover:text-secondary ${
                  link.active
                    ? 'text-primary font-bold border-b-2 border-primary pb-1'
                    : 'text-on-surface-variant font-semibold'
                }`}
              >
                {link.name}
              </a>
            </li>
          ))}
        </ul>

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