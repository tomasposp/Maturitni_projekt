#pragma checksum "..\..\VyberObtiznostiPocitace.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B48ED84C7BC1A379CD875105E6FE19AC406DF98E1D439C8B8767A4A1848A9EE5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using Mat_projekt;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Mat_projekt {
    
    
    /// <summary>
    /// VyberObtiznostiPocitace
    /// </summary>
    public partial class VyberObtiznostiPocitace : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\VyberObtiznostiPocitace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Easy;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\VyberObtiznostiPocitace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Easy_LBL;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\VyberObtiznostiPocitace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Medium;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\VyberObtiznostiPocitace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Medium_LBL;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Mat_projekt;component/vyberobtiznostipocitace.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VyberObtiznostiPocitace.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Easy = ((System.Windows.Controls.Image)(target));
            
            #line 11 "..\..\VyberObtiznostiPocitace.xaml"
            this.Easy.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Easy_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Easy_LBL = ((System.Windows.Controls.Label)(target));
            
            #line 12 "..\..\VyberObtiznostiPocitace.xaml"
            this.Easy_LBL.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Easy_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Medium = ((System.Windows.Controls.Image)(target));
            
            #line 13 "..\..\VyberObtiznostiPocitace.xaml"
            this.Medium.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Medium_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Medium_LBL = ((System.Windows.Controls.Label)(target));
            
            #line 14 "..\..\VyberObtiznostiPocitace.xaml"
            this.Medium_LBL.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Medium_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

