import { useState } from 'react'
import styles from '../../styles/Hero.module.css'

export default function Hero() {
  const [mal, setMal] = useState('')
  const [email, setEmail] = useState('')
  const [submitted, setSubmitted] = useState(false)
  const [errors, setErrors] = useState({ mal: false, email: false })

  function handleSubmit(e: React.FormEvent) {
    e.preventDefault()
    const errs = {
      mal: !mal.trim(),
      email: !email.trim() || !email.includes('@'),
    }
    setErrors(errs)
    if (errs.mal || errs.email) return
    setSubmitted(true)
  }

  return (
    <section className={styles.hero}>
      <div className={styles.left}>
        <h1 className={styles.heading}>
          Your anime watchlist,<br />
          <span className={styles.accent}>curated</span> for you
        </h1>
        <p className={styles.sub}>
          Connect your MyAnimeList account and get a weekly digest of picks,
          hidden gems, and airing shows matched to your taste.
        </p>
        <ul className={styles.perks}>
          <li>Trending picks filtered to your genres</li>
          <li>Hidden gems you'd never find scrolling</li>
          <li>One personalised recommendation every week</li>
        </ul>
      </div>

      <div className={styles.right}>
        {submitted ? (
          <div className={styles.success} role="alert">
            <span className={styles.successIcon} aria-hidden="true">✓</span>
            <h2>You're in</h2>
            <p>Your first digest lands next Friday. We're already reading your MAL list.</p>
            <p className={styles.spamNote}>
              Add <strong>hello@otakudrop.email</strong> to your contacts so we don't end up in spam.
            </p>
          </div>
        ) : (
          <form className={styles.form} onSubmit={handleSubmit} noValidate>
            <div className={styles.formHeader}>
              <h2>Get the weekly drop</h2>
              <p>Free, every Friday.</p>
            </div>  

            <div className={styles.field}>
              <label htmlFor="mal">MAL username</label>
              <input
                id="mal"
                type="text"
                value={mal}
                onChange={e => setMal(e.target.value)}
                placeholder="nakamura_san"
                className={errors.mal ? styles.inputError : ''}
                autoComplete="off"
                aria-invalid={errors.mal}
                aria-describedby={errors.mal ? "mal-error" : undefined}
              />
              {errors.mal && (
                <span id="mal-error" className={styles.error}>
                  Please enter your MAL username
                </span>
              )}
            </div>

            <div className={styles.field}>
              <label htmlFor="email">Email address</label>
              <input
                id="email"
                type="email"
                value={email}
                onChange={e => setEmail(e.target.value)}
                placeholder="you@example.com"
                className={errors.email ? styles.inputError : ''}
                autoComplete="email"
                aria-invalid={errors.email}
                aria-describedby={errors.email ? "email-error" : undefined}
              />
              {errors.email && (
                <span id="email-error" className={styles.error}>
                  Please enter a valid email
                </span>
              )}
            </div>

            <button type="submit" className={styles.btn}>Subscribe</button>

            <p className={styles.disclaimer}>
              Every email includes a one-click unsubscribe. No spam, no data selling.
            </p>
          </form>
        )}
      </div>
    </section>
  )
}