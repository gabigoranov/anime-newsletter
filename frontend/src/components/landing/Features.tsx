import React from "react";
import { FeatureCard } from "./FeatureCard";

// --- TYPE DEFINITIONS ---

export const Features: React.FC = () => {
  return (
    <section className="section-container py-16 md:py-24 bg-background">
      {/* Features Grid Matching image_59a7ea.png Layout Structure */}
      <div className="grid grid-cols-1 gap-6 md:grid-cols-6">
        {/* Row 1: Large Card 1 */}
        <FeatureCard
          isLarge={true}
          title="Hourly Simulcast Radar"
          description="Our automated arrays sweep your personalized watchlist every 60 minutes. The absolute moment a sub or dub goes live, AniMail captures it instantly."
          visualPlaceholder={
            <div className="relative w-full h-full rounded-xl border border-dashed border-(--border) bg-surface-container flex items-center justify-center">
              <div className="absolute inset-0 bg-radial from-(--accent-bg) to-transparent animate-pulse" />
              <code className="text-xs text-primary font-mono z-10">
                [CRON JOB]: Scanning Watchlist... 100%
              </code>
            </div>
          }
        />

        {/* Row 1: Large Card 2 */}
        <FeatureCard
          isLarge={true}
          title="Zero-Spam Smart Dispatches"
          description="Say goodbye to inbox clutter. Receive highly structured, beautiful, and completely unique email notifications tailored explicitly to your current watch session."
          visualPlaceholder={
            <div className="w-full max-w-xs p-4 rounded-xl border border-(--border) bg-surface shadow-sm text-center">
              <div className="h-2 w-16 bg-primary rounded mx-auto mb-2" />
              <div className="h-12 w-full bg-surface-container rounded flex items-center justify-center text-xs font-semibold text-(--text-h)">
                ✨ Episode 12 is Live!
              </div>
            </div>
          }
        />

        {/* Row 2: Small Card 1 */}
        <FeatureCard
          title="Seamless MAL Sync"
          description="Import your complete tracking library instantly. Sync up with your MyAnimeList accounts without touching complex manual migration setups."
          visualPlaceholder={
            <div className="flex items-center gap-4">
              <div className="h-12 w-12 rounded-xl bg-secondary flex items-center justify-center text-white font-bold text-sm">
                MAL
              </div>
              <div className="h-1 w-8 bg-dashed border-t border-(--border)" />
              <div className="h-12 w-12 rounded-xl bg-primary flex items-center justify-center text-white font-bold text-sm">
                ANI
              </div>
            </div>
          }
        />

        {/* Row 2: Small Card 2 */}
        <FeatureCard
          title="AI-Driven Insights"
          description="Get dynamically compiled episode recaps, personalized upcoming seasonal recommendations, and smart spoiler-free narrative deep dives."
          visualPlaceholder={
            <div className="w-full max-w-xs flex flex-col gap-2 p-3 bg-inverse-surface rounded-xl text-left">
              <div className="h-2 w-1/3 bg-primary-container rounded" />
              <div className="h-2 w-full bg-surface-variant rounded opacity-40" />
              <div className="h-2 w-5/6 bg-surface-variant rounded opacity-40" />
            </div>
          }
        />

        {/* Row 2: Small Card 3 */}
        <FeatureCard
          title="Tailored Feed Layouts"
          description="Take complete control of your presentation layers. Tweak density, toggle imagery elements, and configure notification frequencies exactly how you like."
          visualPlaceholder={
            <div className="flex gap-2">
              <div className="h-8 w-8 rounded-full bg-tertiary-container" />
              <div className="h-8 w-8 rounded-full bg-primary-container" />
              <div className="h-8 w-8 rounded-full bg-secondary-container" />
            </div>
          }
        />
      </div>
    </section>
  );
};

export default Features;
