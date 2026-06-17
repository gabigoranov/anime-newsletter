import { useState } from 'react';

type SignUpModalProps = {
  isOpen: boolean;
  onClose: () => void;
  initialEmail?: string;
};

export default function SignUpModal({ isOpen, onClose, initialEmail = '' }: SignUpModalProps) {
  const [email, setEmail] = useState(initialEmail);
  const [malUsername, setMalUsername] = useState('');
  const [agreeTos, setAgreeTos] = useState(false);
  const [agreeEmails, setAgreeEmails] = useState(true);

  // Keep track of the previous open state to detect when the modal opens
  const [prevIsOpen, setPrevIsOpen] = useState(isOpen);

  // React-recommended pattern: Adjust state during render, NOT in a useEffect.
  // This avoids double-renders
  if (isOpen !== prevIsOpen) {
    setPrevIsOpen(isOpen);
    if (isOpen) {
      // Form resets completely every time the modal is opened
      setEmail(initialEmail);
      setMalUsername('');
      setAgreeTos(false);
      setAgreeEmails(true);
    }
  }

  if (!isOpen) return null;

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log({ email, malUsername, agreeTos, agreeEmails });
  };

  return (
    <div 
      className="fixed inset-0 z-50 flex items-center justify-center w-screen h-screen bg-inverse-surface/60 backdrop-blur-sm p-4"
      onClick={onClose} // Closes modal when clicking the blurred background
    >
      
      {/* Modal Container */}
      <div 
        className="relative w-full shrink-0 sm:w-120 max-w-120 bg-surface border border-outline-variant rounded-3xl shadow-2xl overflow-hidden"
        onClick={(e) => e.stopPropagation()} // Prevents clicks inside the form from closing the modal
        role="dialog"
        aria-modal="true"
      >
        {/* Form Body - Increased padding and spacing */}
        <form onSubmit={handleSubmit} className="p-8 sm:p-10 space-y-6 sm:space-y-8">
          
          {/* Email Input */}
          <div className="space-y-2 text-left">
            <label htmlFor="email" className="block text-sm font-semibold text-on-surface-variant">
              Email Address
            </label>
            <input
              type="email"
              id="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="you@example.com"
              className="w-full box-border px-5 py-3.5 bg-surface-container-low border border-outline-variant rounded-xl text-on-surface placeholder:text-outline focus:outline-none focus:ring-2 focus:ring-primary focus:border-primary transition-all font-sans"
              required
            />
          </div>

          {/* MAL Username Input */}
          <div className="space-y-2 text-left">
            <label htmlFor="malUsername" className="block text-sm font-semibold text-on-surface-variant">
              MyAnimeList Username
            </label>
            <input
              type="text"
              id="malUsername"
              value={malUsername}
              onChange={(e) => setMalUsername(e.target.value)}
              placeholder="e.g. SpikeSpiegel99"
              className="w-full box-border px-5 py-3.5 bg-surface-container-low border border-outline-variant rounded-xl text-on-surface placeholder:text-outline focus:outline-none focus:ring-2 focus:ring-primary focus:border-primary transition-all font-sans"
              required
            />
          </div>

          {/* Checkboxes */}
          <div className="space-y-4 pt-2 text-left">
            <label className="flex items-start gap-3 cursor-pointer group">
              <div className="flex items-center h-5 shrink-0">
                <input
                  type="checkbox"
                  checked={agreeTos}
                  onChange={(e) => setAgreeTos(e.target.checked)}
                  className="w-5 h-5 mt-0.5 accent-primary cursor-pointer"
                  required
                />
              </div>
              <span className="text-sm text-outline leading-snug group-hover:text-on-surface-variant transition-colors">
                I agree to the <a href="/tos" className="text-primary font-medium hover:underline">Terms of Service</a> and <a href="/privacy" className="text-primary font-medium hover:underline">Privacy Policy</a>.
              </span>
            </label>

            <label className="flex items-start gap-3 cursor-pointer group">
              <div className="flex items-center h-5 shrink-0">
                <input
                  type="checkbox"
                  checked={agreeEmails}
                  onChange={(e) => setAgreeEmails(e.target.checked)}
                  className="w-5 h-5 mt-0.5 accent-primary cursor-pointer"
                />
              </div>
              <span className="text-sm text-outline leading-snug group-hover:text-on-surface-variant transition-colors">
                I want to receive AniMail newsletters, updates, and special offers.
              </span>
            </label>
          </div>

          {/* Submit Button */}
          <div className="pt-2">
            <button
              type="submit"
              className="w-full py-4 px-6 bg-primary text-on-primary font-bold rounded-full shadow-sm hover:bg-[#8e2a22] hover:shadow-md focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-offset-surface focus:ring-primary transition-all active:scale-[0.98] text-lg"
            >
              Sign Up
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}