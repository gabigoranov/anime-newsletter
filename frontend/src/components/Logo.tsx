interface LogoProps {
  /**
   * Defines the host background type where the logo sits.
   * 'light' outputs dark text for white/light backgrounds.
   * 'dark' outputs light/white text for dark/black backgrounds.
   * @default 'light'
   */
  variant?: 'light' | 'dark';
}

export default function Logo({ variant = 'light' }: LogoProps) {
  // Determine text coloring based on the host background variant
  const baseTextColor = variant === 'light' ? 'text-on-background' : 'text-white';
  const accentTextColor = variant === 'light' ? 'text-primary' : 'text-primary-fixed-dim';

  return (
    <div className="flex items-center gap-2 select-none">
      {/* Wordmark Typography */}
      <span className={`font-display text-2xl font-bold tracking-tight transition-colors duration-200 ${baseTextColor}`}>
        ani<span className={accentTextColor}>mail</span>
      </span>
    </div>
  );
}