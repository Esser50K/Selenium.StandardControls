﻿using System;
using OpenQA.Selenium;
using Selenium.StandardControls.PageObjectUtility;

namespace Selenium.StandardControls
{
    public class RadioButtonDriver : ControlDriverBase
    {
        public RadioButtonDriver(IWebElement element) : base(element){}
        public RadioButtonDriver(IWebElement element, Action wait) : base(element){ Wait = wait; }
        public bool Checked => (bool)JS.ExecuteScript("return arguments[0].checked;", Element);
        public Action Wait { get; set; }

        public void Edit()
        {
            Element.Show();
            Element.Focus();
            if (!Checked)
            {
                Element.SendKeys(Keys.Space);
                JS.ExecuteScript("");//sync.
            }
            Wait?.Invoke();
        }

        public static implicit operator RadioButtonDriver(ElementFinder finder) => new RadioButtonDriver(finder.Find());
    }
}
