.class public Lcom/igg/iggsdkbusiness/IGGWebView;
.super Landroid/app/Activity;
.source "IGGWebView.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/iggsdkbusiness/IGGWebView$MyWebViewClient;
    }
.end annotation


# instance fields
.field bButton:Landroid/widget/Button;

.field et:Landroid/widget/EditText;

.field http:Ljava/lang/String;

.field layoutParams:Landroid/widget/LinearLayout$LayoutParams;

.field layoutParamsButton:Landroid/widget/LinearLayout$LayoutParams;

.field linearLayout:Landroid/widget/LinearLayout;

.field mWebview:Landroid/webkit/WebView;

.field url:Ljava/lang/String;

.field wv:Landroid/webkit/WebView;

.field www:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 32
    invoke-direct {p0}, Landroid/app/Activity;-><init>()V

    .line 37
    const-string v0, "http://www.google.com"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->http:Ljava/lang/String;

    .line 38
    const-string v0, "www."

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->www:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public getUrl(Landroid/view/View;)V
    .locals 1
    .param p1, "v"    # Landroid/view/View;

    .prologue
    .line 185
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->et:Landroid/widget/EditText;

    invoke-virtual {v0}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->url:Ljava/lang/String;

    .line 186
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->url:Ljava/lang/String;

    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGWebView;->validateUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->url:Ljava/lang/String;

    .line 187
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->url:Ljava/lang/String;

    invoke-virtual {p0, v0}, Lcom/igg/iggsdkbusiness/IGGWebView;->openUrl(Ljava/lang/String;)V

    .line 188
    return-void
.end method

.method protected onCreate(Landroid/os/Bundle;)V
    .locals 14
    .param p1, "savedInstanceState"    # Landroid/os/Bundle;

    .prologue
    const/4 v13, 0x0

    const/4 v12, -0x1

    const/4 v11, -0x2

    const/4 v10, 0x1

    .line 49
    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    .line 51
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGWebView;->getIntent()Landroid/content/Intent;

    move-result-object v7

    const-string v8, "Url"

    invoke-virtual {v7, v8}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 53
    .local v4, "pUrl":Ljava/lang/String;
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGWebView;->getWindow()Landroid/view/Window;

    move-result-object v7

    const/16 v8, 0x12

    invoke-virtual {v7, v8}, Landroid/view/Window;->setSoftInputMode(I)V

    .line 56
    invoke-virtual {p0, v10}, Lcom/igg/iggsdkbusiness/IGGWebView;->requestWindowFeature(I)Z

    .line 58
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGWebView;->getIntent()Landroid/content/Intent;

    move-result-object v7

    const-string v8, "setting"

    const/4 v9, 0x6

    invoke-virtual {v7, v8, v9}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I

    move-result v2

    .line 59
    .local v2, "OrientationSetting":I
    invoke-virtual {p0, v2}, Lcom/igg/iggsdkbusiness/IGGWebView;->setRequestedOrientation(I)V

    .line 61
    new-instance v7, Landroid/widget/LinearLayout;

    invoke-direct {v7, p0}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;)V

    iput-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->linearLayout:Landroid/widget/LinearLayout;

    .line 62
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->linearLayout:Landroid/widget/LinearLayout;

    invoke-virtual {v7, v13}, Landroid/widget/LinearLayout;->setOrientation(I)V

    .line 63
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->linearLayout:Landroid/widget/LinearLayout;

    const/16 v8, 0x11

    invoke-virtual {v7, v8}, Landroid/widget/LinearLayout;->setGravity(I)V

    .line 65
    new-instance v7, Landroid/widget/LinearLayout$LayoutParams;

    invoke-direct {v7, v11, v11}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->layoutParamsButton:Landroid/widget/LinearLayout$LayoutParams;

    .line 67
    new-instance v7, Landroid/widget/Button;

    invoke-direct {v7, p0}, Landroid/widget/Button;-><init>(Landroid/content/Context;)V

    iput-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->bButton:Landroid/widget/Button;

    .line 71
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGWebView;->getApplicationContext()Landroid/content/Context;

    move-result-object v7

    invoke-virtual {v7}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v5

    .line 73
    .local v5, "res":Landroid/content/res/Resources;
    const-string v7, "exit"

    const-string v8, "drawable"

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGWebView;->getPackageName()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v5, v7, v8, v9}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v0

    .line 74
    .local v0, "Icon":I
    const-string v7, "exit_press"

    const-string v8, "drawable"

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/IGGWebView;->getPackageName()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v5, v7, v8, v9}, Landroid/content/res/Resources;->getIdentifier(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)I

    move-result v1

    .line 75
    .local v1, "IconPress":I
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->bButton:Landroid/widget/Button;

    invoke-virtual {v7, v0}, Landroid/widget/Button;->setBackgroundResource(I)V

    .line 78
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->bButton:Landroid/widget/Button;

    new-instance v8, Lcom/igg/iggsdkbusiness/IGGWebView$1;

    invoke-direct {v8, p0, v1, v0}, Lcom/igg/iggsdkbusiness/IGGWebView$1;-><init>(Lcom/igg/iggsdkbusiness/IGGWebView;II)V

    invoke-virtual {v7, v8}, Landroid/widget/Button;->setOnTouchListener(Landroid/view/View$OnTouchListener;)V

    .line 95
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->bButton:Landroid/widget/Button;

    iget-object v8, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->layoutParamsButton:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v7, v8}, Landroid/widget/Button;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 96
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->linearLayout:Landroid/widget/LinearLayout;

    iget-object v8, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->bButton:Landroid/widget/Button;

    invoke-virtual {v7, v8}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 98
    new-instance v7, Landroid/widget/LinearLayout$LayoutParams;

    invoke-direct {v7, v12, v12}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    .line 99
    new-instance v7, Landroid/webkit/WebView;

    invoke-direct {v7, p0}, Landroid/webkit/WebView;-><init>(Landroid/content/Context;)V

    iput-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    .line 100
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    iget-object v8, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v7, v8}, Landroid/webkit/WebView;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 101
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->linearLayout:Landroid/widget/LinearLayout;

    iget-object v8, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    invoke-virtual {v7, v8}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 102
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    invoke-virtual {v7}, Landroid/webkit/WebView;->getSettings()Landroid/webkit/WebSettings;

    move-result-object v6

    .line 103
    .local v6, "webSettings":Landroid/webkit/WebSettings;
    invoke-virtual {v6, v10}, Landroid/webkit/WebSettings;->setJavaScriptEnabled(Z)V

    .line 104
    invoke-virtual {v6, v10}, Landroid/webkit/WebSettings;->setJavaScriptCanOpenWindowsAutomatically(Z)V

    .line 105
    invoke-virtual {v6, v10}, Landroid/webkit/WebSettings;->setAllowFileAccess(Z)V

    .line 106
    invoke-virtual {v6, v10}, Landroid/webkit/WebSettings;->setSupportZoom(Z)V

    .line 107
    invoke-virtual {v6, v13}, Landroid/webkit/WebSettings;->setBuiltInZoomControls(Z)V

    .line 108
    invoke-virtual {v6, v10}, Landroid/webkit/WebSettings;->setJavaScriptCanOpenWindowsAutomatically(Z)V

    .line 109
    const/4 v7, 0x2

    invoke-virtual {v6, v7}, Landroid/webkit/WebSettings;->setCacheMode(I)V

    .line 110
    invoke-virtual {v6, v10}, Landroid/webkit/WebSettings;->setDomStorageEnabled(Z)V

    .line 111
    invoke-virtual {v6, v10}, Landroid/webkit/WebSettings;->setDatabaseEnabled(Z)V

    .line 113
    move-object v3, p0

    .line 114
    .local v3, "activity":Landroid/app/Activity;
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    new-instance v8, Lcom/igg/iggsdkbusiness/IGGWebView$2;

    invoke-direct {v8, p0}, Lcom/igg/iggsdkbusiness/IGGWebView$2;-><init>(Lcom/igg/iggsdkbusiness/IGGWebView;)V

    invoke-virtual {v7, v8}, Landroid/webkit/WebView;->setWebChromeClient(Landroid/webkit/WebChromeClient;)V

    .line 136
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    new-instance v8, Lcom/igg/iggsdkbusiness/IGGWebView$3;

    invoke-direct {v8, p0}, Lcom/igg/iggsdkbusiness/IGGWebView$3;-><init>(Lcom/igg/iggsdkbusiness/IGGWebView;)V

    invoke-virtual {v7, v8}, Landroid/webkit/WebView;->setWebViewClient(Landroid/webkit/WebViewClient;)V

    .line 144
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    invoke-virtual {v7, v4}, Landroid/webkit/WebView;->loadUrl(Ljava/lang/String;)V

    .line 145
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->linearLayout:Landroid/widget/LinearLayout;

    iget-object v8, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {p0, v7, v8}, Lcom/igg/iggsdkbusiness/IGGWebView;->setContentView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    .line 146
    iget-object v7, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->bButton:Landroid/widget/Button;

    new-instance v8, Lcom/igg/iggsdkbusiness/IGGWebView$4;

    invoke-direct {v8, p0}, Lcom/igg/iggsdkbusiness/IGGWebView$4;-><init>(Lcom/igg/iggsdkbusiness/IGGWebView;)V

    invoke-virtual {v7, v8}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 162
    return-void
.end method

.method public onDestroy()V
    .locals 2

    .prologue
    .line 167
    invoke-super {p0}, Landroid/app/Activity;->onDestroy()V

    .line 168
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    if-eqz v0, :cond_0

    .line 170
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    const/16 v1, 0x8

    invoke-virtual {v0, v1}, Landroid/webkit/WebView;->setVisibility(I)V

    .line 171
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->mWebview:Landroid/webkit/WebView;

    invoke-virtual {v0}, Landroid/webkit/WebView;->destroy()V

    .line 173
    :cond_0
    return-void
.end method

.method public openUrl(Ljava/lang/String;)V
    .locals 2
    .param p1, "url"    # Ljava/lang/String;

    .prologue
    .line 192
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->wv:Landroid/webkit/WebView;

    const/16 v1, 0x50

    invoke-virtual {v0, v1}, Landroid/webkit/WebView;->setInitialScale(I)V

    .line 193
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->wv:Landroid/webkit/WebView;

    invoke-virtual {v0, p1}, Landroid/webkit/WebView;->loadUrl(Ljava/lang/String;)V

    .line 194
    return-void
.end method

.method public validateUrl(Ljava/lang/String;)Ljava/lang/String;
    .locals 2
    .param p1, "url"    # Ljava/lang/String;

    .prologue
    .line 176
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->www:Ljava/lang/String;

    invoke-virtual {p1, v0}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->http:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    .line 179
    :cond_0
    :goto_0
    return-object p1

    .line 177
    :cond_1
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->http:Ljava/lang/String;

    invoke-virtual {p1, v0}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->www:Ljava/lang/String;

    invoke-virtual {p1, v0}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 178
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->http:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGWebView;->www:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    goto :goto_0
.end method
