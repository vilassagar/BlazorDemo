// MxUI JavaScript Interop Module
// Minimal JS - only what Blazor can't do natively

export const MxUI = {
    /**
     * Apply CSS variables to document root and persist theme preference.
     */
    applyTheme(cssVars, themeName) {
        // Remove existing theme style if present
        let styleEl = document.getElementById('mxui-theme-vars');
        if (!styleEl) {
            styleEl = document.createElement('style');
            styleEl.id = 'mxui-theme-vars';
            document.head.appendChild(styleEl);
        }
        styleEl.textContent = cssVars;

        // Toggle dark class on html element
        document.documentElement.classList.toggle('dark', themeName === 'dark');
        
        // Persist preference
        try {
            localStorage.setItem('mxui-theme', themeName);
        } catch { /* SSR or restricted context */ }
    },

    /**
     * Get saved theme preference.
     */
    getThemePreference() {
        try {
            return localStorage.getItem('mxui-theme');
        } catch {
            return null;
        }
    },

    /**
     * Show/hide modal with focus trap and body scroll lock.
     */
    modalOpen(modalId) {
        const modal = document.getElementById(modalId);
        if (!modal) return;
        
        document.body.style.overflow = 'hidden';
        
        // Focus first focusable element
        const focusable = modal.querySelectorAll(
            'button, [href], input, select, textarea, [tabindex]:not([tabindex="-1"])'
        );
        if (focusable.length) focusable[0].focus();
    },

    modalClose() {
        document.body.style.overflow = '';
    },

    /**
     * Position dropdown relative to trigger element.
     */
    positionDropdown(triggerId, dropdownId, placement = 'bottom-start') {
        const trigger = document.getElementById(triggerId);
        const dropdown = document.getElementById(dropdownId);
        if (!trigger || !dropdown) return;

        const rect = trigger.getBoundingClientRect();
        const style = dropdown.style;

        switch (placement) {
            case 'bottom-start':
                style.top = `${rect.bottom + 4}px`;
                style.left = `${rect.left}px`;
                break;
            case 'bottom-end':
                style.top = `${rect.bottom + 4}px`;
                style.right = `${window.innerWidth - rect.right}px`;
                break;
            case 'top-start':
                style.bottom = `${window.innerHeight - rect.top + 4}px`;
                style.left = `${rect.left}px`;
                break;
        }
    },

    /**
     * Click-outside detection for dropdowns.
     */
    onClickOutside(elementId, dotNetRef) {
        const handler = (e) => {
            const el = document.getElementById(elementId);
            if (el && !el.contains(e.target)) {
                dotNetRef.invokeMethodAsync('OnClickOutside');
            }
        };
        document.addEventListener('click', handler, true);
        return { dispose: () => document.removeEventListener('click', handler, true) };
    },

    /**
     * Copy text to clipboard.
     */
    async copyToClipboard(text) {
        await navigator.clipboard.writeText(text);
    },

    /**
     * Debounced input for search/filter fields.
     */
    debounce(dotNetRef, methodName, delay = 300) {
        let timer;
        return (value) => {
            clearTimeout(timer);
            timer = setTimeout(() => {
                dotNetRef.invokeMethodAsync(methodName, value);
            }, delay);
        };
    }
};
