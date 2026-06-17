import { LucideMailCheck, LucideSendHorizontal } from "lucide-react";
import { useModal } from "../../hooks/useModal";
import { useState } from "react";

export default function Hero() {
  const { openSignup } = useModal();
  const [email, setEmail] = useState<string>();
  const isValidEmail = (value: string) => {
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value.trim());
  };

  return (
    <section className="relative max-w-7xl mx-auto py-xl lg:py-3xl w-full">
      <div className="section-container flex flex-col-reverse md:flex-row items-center gap-xl">
        {/* Left Content Column */}
        <div className="flex-1 flex flex-col gap-md z-10 text-center md:text-left">
          <h1 className="font-display text-display text-on-surface leading-tight">
            Never Miss an <br className="hidden lg:block" />
            <span className="text-primary relative inline-block">
              Anime Update
              {/* SVG Underline Highlight */}
              <svg
                className="absolute w-full h-3 -bottom-1 left-0 text-primary-container"
                preserveAspectRatio="none"
                viewBox="0 0 100 10"
              >
                <path
                  d="M0 5 Q 50 10 100 5"
                  fill="none"
                  stroke="currentColor"
                  strokeWidth="4"
                ></path>
              </svg>
            </span>{" "}
            Again.
          </h1>

          <p className="font-body-lg text-body-lg text-on-surface-variant max-w-6/7 mx-auto md:mx-0">
            Never miss an episode. Sync your MyAnimeList account and receive
            hourly updates, breaking anime news, release alerts, and AI-powered
            summaries—all for free. I am currently testing the CI/CD AGAIN
          </p>

          <form
            className="flex flex-col sm:flex-row gap-sm mt-sm w-full max-w-md mx-auto md:mx-0"
            onSubmit={(e) => e.preventDefault()}
          >
            <div className="relative flex-1">
              <LucideMailCheck className="absolute left-3.5 top-1/2 transform -translate-y-1/2 text-outline" />
              <input
                className="pl-lg pr-md py-sm rounded-full border-2 border-outline-variant bg-surface text-on-surface font-body-md focus:border-secondary focus:ring-4 focus:ring-secondary/10 transition-all outline-none placeholder:text-outline"
                placeholder="Enter your email"
                required
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>
            <button
              className="bg-primary text-on-primary px-lg py-sm rounded-full font-label-md text-label-md hover:scale-105 hover:bg-surface-tint active:scale-95 transition-all shadow-lg shadow-primary/25 whitespace-nowrap flex items-center justify-center gap-sm"
              type="submit"
              onClick={() => {
                const trimmed = email?.trim();

                if (!isValidEmail(trimmed || "")) {
                  return;
                }

                openSignup(trimmed);
              }}
            >
              Join Waitlist <LucideSendHorizontal className="text-on-primary" />
            </button>
          </form>
        </div>

        {/* Right Graphic Column */}
        <div className="flex-1 relative z-10 w-full flex justify-center perspective-1000">
          <div className="relative w-full max-w-125">
            {/* Subtle image glow effect */}
            <div className="absolute inset-0 bg-linear-to-tr from-primary-fixed to-secondary-fixed rounded-full blur-3xl opacity-20 -z-10"></div>
            <img
              alt="AniMail Robot Mascot Flying"
              className="w-full h-auto object-contain drop-shadow-2xl"
              src="https://lh3.googleusercontent.com/aida/AP1WRLuAFhfZSL5xD9PvwFjuI0mntOz1ihVBhIOxVCyPQFNMs5_WUW_zA_P2J_u38L6wA9DLFTZl-TvpvNeLd90Ys4tVt0pvdlHWbGYbFzmhTgdDqKv5_W5Su08z6QUgw9Ex5eMPXm617mWBC5YWz1dU7Qe_JKIREwhSfFn-X56l4o_snbJhCv1B4y8VtFD-FUpKrIWGMg2dA9eimNj1ElmfEIr6yEsVOq9GofzIhG_Iu-eop-wYI8G-BVemJKc"
            />
          </div>
        </div>
      </div>
    </section>
  );
}
