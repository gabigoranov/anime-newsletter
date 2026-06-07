import { useModal } from "../../hooks/useModal";

export default function CtaBanner() {
  const { openSignup } = useModal();

  return (
    <div className="relative w-full overflow-hidden rounded-3xl border border-outline-variant bg-surface-container-low p-8 md:p-12 text-left shadow-xl">
      {/* Background Soft Linear Overlay */}
      <div className="absolute inset-0 bg-linear-to-br from-primary/5 via-transparent to-secondary/5 pointer-events-none" />

      {/* Main Container Layout */}
      <div className="relative z-10 flex flex-col md:flex-row items-center justify-between gap-8">
        {/* Left Side: Text and Interaction Content */}
        <div className="max-w-1/3 flex flex-col items-start gap-4">
          <h2 className="font-display text-3xl font-extrabold tracking-tight text-on-background sm:text-4xl">
            Quit forgetting about new releases
          </h2>
          <p className="font-body-md text-on-background leading-relaxed">
            10,000+ anime catalog endpoints synchronized every single hour. No
            delayed feeds, no missed episodes.
          </p>
          <div className="pt-2">
            <button
              className="hidden md:block bg-primary text-on-primary font-semibold text-label-md px-gutter py-sm rounded-full hover:scale-105 active:scale-95 transition-all shadow-md shadow-primary/20 duration-200"
              onClick={() => openSignup()}
            >
              Get Started
            </button>
          </div>
        </div>

        {/* Right Side: Graphic Visual Placeholder */}
        <div className="w-full md:w-[40%] aspect-video md:aspect-auto md:h-48 rounded-2xl border border-outline-variant bg-surface flex items-center justify-center overflow-hidden shadow-xs">
          {/* Placeholder Mesh / Glowing Globe Graphic */}
          <div className="relative w-full h-full flex items-center justify-center opacity-70">
            <div className="absolute w-40 h-40 rounded-full border border-dashed border-primary/20 animate-spin [animation-duration:20s]" />
            <div className="absolute w-28 h-28 rounded-full border border-dotted border-secondary/30 animate-spin [animation-duration:12s] reverse" />
            <span className="font-mono text-xs text-primary font-semibold tracking-widest uppercase">
              [ Global Sync Map ]
            </span>
          </div>
        </div>
      </div>
    </div>
  );
}
