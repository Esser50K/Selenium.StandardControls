﻿using System;
using OpenQA.Selenium;
using Selenium.StandardControls.PageObjectUtility;

namespace Selenium.StandardControls
{
    public class ButtonDriver : ControlDriverBase
    {
        public ButtonDriver(IWebElement element) : base(element){}
        public ButtonDriver(IWebElement element, Action wait = null) : base(element){ Wait = wait; }

        public string Text => Info.Value;
        public Action Wait { get; set; }

        public void Invoke()
        {
            Element.Show();
            Element.SendKeys(Keys.Space);
            Wait?.Invoke();
        }

        public static implicit operator ButtonDriver(ElementFinder finder)=> new ButtonDriver(finder.Find());
    }
}
