import type React from 'react';

export interface FeatureCardProps {
  title: string;
  description: string;
  visualPlaceholder: React.ReactNode;
  isLarge?: boolean;
}

export const FeatureCard: React.FC<FeatureCardProps> = ({
    title, description, visualPlaceholder, isLarge = false
}) => {
    return (
        <div
            className={`
        flex flex-col justify-between overflow-hidden rounded-3xl 
        border border-(--border) bg-surface text-left 
        transition-all duration-300 hover:shadow-lg
        ${isLarge ? 'md:col-span-3' : 'md:col-span-2'}
      `}
        >
            {/* Visual Placeholder Container */}
            <div className="flex h-56 w-full items-center justify-center bg-surface-container-low p-6">
                {visualPlaceholder}
            </div>

            {/* Content Block */}
            <div className="p-8">
                <h3 className="font-headline-md text-xl font-bold tracking-tight text-(--text-h) md:text-2xl mb-2">
                    {title}
                </h3>
                <p className="font-body-md text-base text-(--text) leading-relaxed">
                    {description}
                </p>
            </div>
        </div>
    );
};
