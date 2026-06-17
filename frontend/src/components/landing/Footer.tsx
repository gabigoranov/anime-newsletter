import React from "react";
import CtaBanner from "./CtaBanner";
import Logo from "../Logo";

export const Footer: React.FC = () => {
  return (
    // mx-[-1px] actively counters and eliminates the global 1px layout bounding-box borders 
    <footer className="relative w-full bg-surface-container text-text pt-32 pb-8 mt-150 -mx-px border-t border-outline-variant/30">
      {/* Structural Wrapper matching global layouts */}
      <div className="section-container">
        
        {/* Floating CTA Banner Container Section */}
        <div className="absolute top-[-10%] left-1/2 w-full max-w-(--breakpoint-xl) -translate-x-1/2 -translate-y-1/2 px-4 md:px-16">
          <CtaBanner />
        </div>

        {/* Primary Footer Directory Content */}
        <div className="grid grid-cols-1 gap-12 md:grid-cols-12 pt-16 pb-16 text-left border-b border-outline-variant/40">
          
          {/* Brand Presentation Column */}
          <div className="space-y-6 md:col-span-5">
            <Logo variant="light" />
            <p className="font-body-md text-sm text-text/80 leading-relaxed">
              Bringing real-time simulcast tracking and curation straight to your inbox.
            </p>
          </div>

          {/* Quick Links Column */}
          <div className="space-y-4 md:col-span-2 md:col-start-7">
            <h4 className="font-display text-sm font-bold tracking-wide text-on-background uppercase opacity-90">
              Quick links
            </h4>
            <ul className="space-y-2.5 text-sm font-medium">
              <li>
                <a href="#pricing" className="hover:text-primary transition-colors duration-200">
                  Pricing Plans
                </a>
              </li>
              <li>
                <a href="#features" className="hover:text-primary transition-colors duration-200">
                  Core Features
                </a>
              </li>
              <li>
                <a href="#schedule" className="hover:text-primary transition-colors duration-200">
                  Release Schedule
                </a>
              </li>
              <li>
                <a href="#faq" className="hover:text-primary transition-colors duration-200">
                  Help & FAQ
                </a>
              </li>
              <li>
                <a href="#status" className="hover:text-primary transition-colors duration-200">
                  System Status
                </a>
              </li>
            </ul>
          </div>

          {/* Social Directory Column */}
          <div className="space-y-4 md:col-span-2">
            <h4 className="font-display text-sm font-bold tracking-wide text-on-background uppercase opacity-90">
              Social
            </h4>
            <ul className="space-y-2.5 text-sm font-medium">
              <li>
                <a href="#discord" className="hover:text-primary transition-colors duration-200">
                  Discord Community
                </a>
              </li>
              <li>
                <a href="#twitter" className="hover:text-primary transition-colors duration-200">
                  X / Twitter
                </a>
              </li>
              <li>
                <a href="#mal" className="hover:text-primary transition-colors duration-200">
                  MyAnimeList Club
                </a>
              </li>
              <li>
                <a href="#github" className="hover:text-primary transition-colors duration-200">
                  GitHub Engine
                </a>
              </li>
              <li>
                <a href="#crunchy" className="hover:text-primary transition-colors duration-200">
                  Crunchyroll Space
                </a>
              </li>
            </ul>
          </div>

          {/* Legal Compliance Column */}
          <div className="space-y-4 md:col-span-2">
            <h4 className="font-display text-sm font-bold tracking-wide text-on-background uppercase opacity-90">
              Legal
            </h4>
            <ul className="space-y-2.5 text-sm font-medium">
              <li>
                <a href="#terms" className="hover:text-primary transition-colors duration-200">
                  Terms of service
                </a>
              </li>
              <li>
                <a href="#privacy" className="hover:text-primary transition-colors duration-200">
                  Privacy policy
                </a>
              </li>
              <li>
                <a href="#cookie" className="hover:text-primary transition-colors duration-200">
                  Cookie policy
                </a>
              </li>
              <li>
                <a href="#dmca" className="hover:text-primary transition-colors duration-200">
                  DMCA Guidelines
                </a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;