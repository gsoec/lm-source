.class public Lcom/facebook/login/widget/LoginButton;
.super Lcom/facebook/FacebookButtonBase;
.source "LoginButton.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/facebook/login/widget/LoginButton$LoginClickListener;,
        Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;,
        Lcom/facebook/login/widget/LoginButton$ToolTipMode;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String;


# instance fields
.field private accessTokenTracker:Lcom/facebook/AccessTokenTracker;

.field private confirmLogout:Z

.field private loginLogoutEventName:Ljava/lang/String;

.field private loginManager:Lcom/facebook/login/LoginManager;

.field private loginText:Ljava/lang/String;

.field private logoutText:Ljava/lang/String;

.field private properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

.field private toolTipChecked:Z

.field private toolTipDisplayTime:J

.field private toolTipMode:Lcom/facebook/login/widget/LoginButton$ToolTipMode;

.field private toolTipPopup:Lcom/facebook/login/widget/ToolTipPopup;

.field private toolTipStyle:Lcom/facebook/login/widget/ToolTipPopup$Style;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 110
    const-class v0, Lcom/facebook/login/widget/LoginButton;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/facebook/login/widget/LoginButton;->TAG:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;)V
    .locals 7
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    const/4 v3, 0x0

    .line 186
    const/4 v2, 0x0

    const-string v5, "fb_login_button_create"

    const-string v6, "fb_login_button_did_tap"

    move-object v0, p0

    move-object v1, p1

    move v4, v3

    invoke-direct/range {v0 .. v6}, Lcom/facebook/FacebookButtonBase;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V

    .line 114
    new-instance v0, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-direct {v0}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;-><init>()V

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    .line 115
    const-string v0, "fb_login_view_usage"

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->loginLogoutEventName:Ljava/lang/String;

    .line 117
    sget-object v0, Lcom/facebook/login/widget/ToolTipPopup$Style;->BLUE:Lcom/facebook/login/widget/ToolTipPopup$Style;

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipStyle:Lcom/facebook/login/widget/ToolTipPopup$Style;

    .line 119
    const-wide/16 v0, 0x1770

    iput-wide v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipDisplayTime:J

    .line 193
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 7
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "attrs"    # Landroid/util/AttributeSet;

    .prologue
    const/4 v3, 0x0

    .line 201
    const-string v5, "fb_login_button_create"

    const-string v6, "fb_login_button_did_tap"

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move v4, v3

    invoke-direct/range {v0 .. v6}, Lcom/facebook/FacebookButtonBase;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V

    .line 114
    new-instance v0, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-direct {v0}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;-><init>()V

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    .line 115
    const-string v0, "fb_login_view_usage"

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->loginLogoutEventName:Ljava/lang/String;

    .line 117
    sget-object v0, Lcom/facebook/login/widget/ToolTipPopup$Style;->BLUE:Lcom/facebook/login/widget/ToolTipPopup$Style;

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipStyle:Lcom/facebook/login/widget/ToolTipPopup$Style;

    .line 119
    const-wide/16 v0, 0x1770

    iput-wide v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipDisplayTime:J

    .line 208
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 7
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "attrs"    # Landroid/util/AttributeSet;
    .param p3, "defStyle"    # I

    .prologue
    .line 216
    const/4 v4, 0x0

    const-string v5, "fb_login_button_create"

    const-string v6, "fb_login_button_did_tap"

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move v3, p3

    invoke-direct/range {v0 .. v6}, Lcom/facebook/FacebookButtonBase;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V

    .line 114
    new-instance v0, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-direct {v0}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;-><init>()V

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    .line 115
    const-string v0, "fb_login_view_usage"

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->loginLogoutEventName:Ljava/lang/String;

    .line 117
    sget-object v0, Lcom/facebook/login/widget/ToolTipPopup$Style;->BLUE:Lcom/facebook/login/widget/ToolTipPopup$Style;

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipStyle:Lcom/facebook/login/widget/ToolTipPopup$Style;

    .line 119
    const-wide/16 v0, 0x1770

    iput-wide v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipDisplayTime:J

    .line 223
    return-void
.end method

.method static synthetic access$000(Lcom/facebook/login/widget/LoginButton;Lcom/facebook/internal/Utility$FetchedAppSettings;)V
    .locals 0
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;
    .param p1, "x1"    # Lcom/facebook/internal/Utility$FetchedAppSettings;

    .prologue
    .line 55
    invoke-direct {p0, p1}, Lcom/facebook/login/widget/LoginButton;->showToolTipPerSettings(Lcom/facebook/internal/Utility$FetchedAppSettings;)V

    return-void
.end method

.method static synthetic access$100(Lcom/facebook/login/widget/LoginButton;)Landroid/app/Activity;
    .locals 1
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;

    .prologue
    .line 55
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$1000(Lcom/facebook/login/widget/LoginButton;)Z
    .locals 1
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;

    .prologue
    .line 55
    iget-boolean v0, p0, Lcom/facebook/login/widget/LoginButton;->confirmLogout:Z

    return v0
.end method

.method static synthetic access$200(Lcom/facebook/login/widget/LoginButton;)V
    .locals 0
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;

    .prologue
    .line 55
    invoke-direct {p0}, Lcom/facebook/login/widget/LoginButton;->setButtonText()V

    return-void
.end method

.method static synthetic access$300(Lcom/facebook/login/widget/LoginButton;Landroid/view/View;)V
    .locals 0
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;
    .param p1, "x1"    # Landroid/view/View;

    .prologue
    .line 55
    invoke-virtual {p0, p1}, Lcom/facebook/login/widget/LoginButton;->callExternalOnClickListener(Landroid/view/View;)V

    return-void
.end method

.method static synthetic access$400(Lcom/facebook/login/widget/LoginButton;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;

    .prologue
    .line 55
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->loginLogoutEventName:Ljava/lang/String;

    return-object v0
.end method

.method static synthetic access$500(Lcom/facebook/login/widget/LoginButton;)Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;
    .locals 1
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;

    .prologue
    .line 55
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    return-object v0
.end method

.method static synthetic access$800(Lcom/facebook/login/widget/LoginButton;)Landroid/app/Activity;
    .locals 1
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;

    .prologue
    .line 55
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$900(Lcom/facebook/login/widget/LoginButton;)Landroid/app/Activity;
    .locals 1
    .param p0, "x0"    # Lcom/facebook/login/widget/LoginButton;

    .prologue
    .line 55
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method private checkToolTipSettings()V
    .locals 4

    .prologue
    .line 484
    sget-object v2, Lcom/facebook/login/widget/LoginButton$3;->$SwitchMap$com$facebook$login$widget$LoginButton$ToolTipMode:[I

    iget-object v3, p0, Lcom/facebook/login/widget/LoginButton;->toolTipMode:Lcom/facebook/login/widget/LoginButton$ToolTipMode;

    invoke-virtual {v3}, Lcom/facebook/login/widget/LoginButton$ToolTipMode;->ordinal()I

    move-result v3

    aget v2, v2, v3

    packed-switch v2, :pswitch_data_0

    .line 509
    :goto_0
    return-void

    .line 487
    :pswitch_0
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getContext()Landroid/content/Context;

    move-result-object v2

    invoke-static {v2}, Lcom/facebook/internal/Utility;->getMetadataApplicationId(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    .line 488
    .local v0, "appId":Ljava/lang/String;
    invoke-static {}, Lcom/facebook/FacebookSdk;->getExecutor()Ljava/util/concurrent/Executor;

    move-result-object v2

    new-instance v3, Lcom/facebook/login/widget/LoginButton$1;

    invoke-direct {v3, p0, v0}, Lcom/facebook/login/widget/LoginButton$1;-><init>(Lcom/facebook/login/widget/LoginButton;Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/concurrent/Executor;->execute(Ljava/lang/Runnable;)V

    goto :goto_0

    .line 502
    .end local v0    # "appId":Ljava/lang/String;
    :pswitch_1
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getResources()Landroid/content/res/Resources;

    move-result-object v2

    sget v3, Lcom/facebook/R$string;->com_facebook_tooltip_default:I

    invoke-virtual {v2, v3}, Landroid/content/res/Resources;->getString(I)Ljava/lang/String;

    move-result-object v1

    .line 504
    .local v1, "toolTipString":Ljava/lang/String;
    invoke-direct {p0, v1}, Lcom/facebook/login/widget/LoginButton;->displayToolTip(Ljava/lang/String;)V

    goto :goto_0

    .line 484
    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
    .end packed-switch
.end method

.method private displayToolTip(Ljava/lang/String;)V
    .locals 4
    .param p1, "toolTipString"    # Ljava/lang/String;

    .prologue
    .line 477
    new-instance v0, Lcom/facebook/login/widget/ToolTipPopup;

    invoke-direct {v0, p1, p0}, Lcom/facebook/login/widget/ToolTipPopup;-><init>(Ljava/lang/String;Landroid/view/View;)V

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipPopup:Lcom/facebook/login/widget/ToolTipPopup;

    .line 478
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipPopup:Lcom/facebook/login/widget/ToolTipPopup;

    iget-object v1, p0, Lcom/facebook/login/widget/LoginButton;->toolTipStyle:Lcom/facebook/login/widget/ToolTipPopup$Style;

    invoke-virtual {v0, v1}, Lcom/facebook/login/widget/ToolTipPopup;->setStyle(Lcom/facebook/login/widget/ToolTipPopup$Style;)V

    .line 479
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipPopup:Lcom/facebook/login/widget/ToolTipPopup;

    iget-wide v2, p0, Lcom/facebook/login/widget/LoginButton;->toolTipDisplayTime:J

    invoke-virtual {v0, v2, v3}, Lcom/facebook/login/widget/ToolTipPopup;->setNuxDisplayTime(J)V

    .line 480
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipPopup:Lcom/facebook/login/widget/ToolTipPopup;

    invoke-virtual {v0}, Lcom/facebook/login/widget/ToolTipPopup;->show()V

    .line 481
    return-void
.end method

.method private measureButtonWidth(Ljava/lang/String;)I
    .locals 4
    .param p1, "text"    # Ljava/lang/String;

    .prologue
    .line 640
    invoke-virtual {p0, p1}, Lcom/facebook/login/widget/LoginButton;->measureTextWidth(Ljava/lang/String;)I

    move-result v0

    .line 641
    .local v0, "textWidth":I
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getCompoundPaddingLeft()I

    move-result v2

    .line 642
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getCompoundDrawablePadding()I

    move-result v3

    add-int/2addr v2, v3

    add-int/2addr v2, v0

    .line 644
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getCompoundPaddingRight()I

    move-result v3

    add-int v1, v2, v3

    .line 645
    .local v1, "width":I
    return v1
.end method

.method private parseLoginButtonAttributes(Landroid/content/Context;Landroid/util/AttributeSet;II)V
    .locals 3
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "attrs"    # Landroid/util/AttributeSet;
    .param p3, "defStyleAttr"    # I
    .param p4, "defStyleRes"    # I

    .prologue
    .line 590
    sget-object v1, Lcom/facebook/login/widget/LoginButton$ToolTipMode;->DEFAULT:Lcom/facebook/login/widget/LoginButton$ToolTipMode;

    iput-object v1, p0, Lcom/facebook/login/widget/LoginButton;->toolTipMode:Lcom/facebook/login/widget/LoginButton$ToolTipMode;

    .line 591
    invoke-virtual {p1}, Landroid/content/Context;->getTheme()Landroid/content/res/Resources$Theme;

    move-result-object v1

    sget-object v2, Lcom/facebook/R$styleable;->com_facebook_login_view:[I

    invoke-virtual {v1, p2, v2, p3, p4}, Landroid/content/res/Resources$Theme;->obtainStyledAttributes(Landroid/util/AttributeSet;[III)Landroid/content/res/TypedArray;

    move-result-object v0

    .line 597
    .local v0, "a":Landroid/content/res/TypedArray;
    :try_start_0
    sget v1, Lcom/facebook/R$styleable;->com_facebook_login_view_com_facebook_confirm_logout:I

    const/4 v2, 0x1

    invoke-virtual {v0, v1, v2}, Landroid/content/res/TypedArray;->getBoolean(IZ)Z

    move-result v1

    iput-boolean v1, p0, Lcom/facebook/login/widget/LoginButton;->confirmLogout:Z

    .line 598
    sget v1, Lcom/facebook/R$styleable;->com_facebook_login_view_com_facebook_login_text:I

    invoke-virtual {v0, v1}, Landroid/content/res/TypedArray;->getString(I)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/facebook/login/widget/LoginButton;->loginText:Ljava/lang/String;

    .line 599
    sget v1, Lcom/facebook/R$styleable;->com_facebook_login_view_com_facebook_logout_text:I

    invoke-virtual {v0, v1}, Landroid/content/res/TypedArray;->getString(I)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/facebook/login/widget/LoginButton;->logoutText:Ljava/lang/String;

    .line 600
    sget v1, Lcom/facebook/R$styleable;->com_facebook_login_view_com_facebook_tooltip_mode:I

    sget-object v2, Lcom/facebook/login/widget/LoginButton$ToolTipMode;->DEFAULT:Lcom/facebook/login/widget/LoginButton$ToolTipMode;

    .line 602
    invoke-virtual {v2}, Lcom/facebook/login/widget/LoginButton$ToolTipMode;->getValue()I

    move-result v2

    .line 600
    invoke-virtual {v0, v1, v2}, Landroid/content/res/TypedArray;->getInt(II)I

    move-result v1

    invoke-static {v1}, Lcom/facebook/login/widget/LoginButton$ToolTipMode;->fromInt(I)Lcom/facebook/login/widget/LoginButton$ToolTipMode;

    move-result-object v1

    iput-object v1, p0, Lcom/facebook/login/widget/LoginButton;->toolTipMode:Lcom/facebook/login/widget/LoginButton$ToolTipMode;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 604
    invoke-virtual {v0}, Landroid/content/res/TypedArray;->recycle()V

    .line 606
    return-void

    .line 604
    :catchall_0
    move-exception v1

    invoke-virtual {v0}, Landroid/content/res/TypedArray;->recycle()V

    throw v1
.end method

.method private setButtonText()V
    .locals 5

    .prologue
    .line 649
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getResources()Landroid/content/res/Resources;

    move-result-object v1

    .line 650
    .local v1, "resources":Landroid/content/res/Resources;
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->isInEditMode()Z

    move-result v4

    if-nez v4, :cond_1

    invoke-static {}, Lcom/facebook/AccessToken;->getCurrentAccessToken()Lcom/facebook/AccessToken;

    move-result-object v4

    if-eqz v4, :cond_1

    .line 651
    iget-object v4, p0, Lcom/facebook/login/widget/LoginButton;->logoutText:Ljava/lang/String;

    if-eqz v4, :cond_0

    iget-object v4, p0, Lcom/facebook/login/widget/LoginButton;->logoutText:Ljava/lang/String;

    :goto_0
    invoke-virtual {p0, v4}, Lcom/facebook/login/widget/LoginButton;->setText(Ljava/lang/CharSequence;)V

    .line 673
    :goto_1
    return-void

    .line 651
    :cond_0
    sget v4, Lcom/facebook/R$string;->com_facebook_loginview_log_out_button:I

    .line 653
    invoke-virtual {v1, v4}, Landroid/content/res/Resources;->getString(I)Ljava/lang/String;

    move-result-object v4

    goto :goto_0

    .line 655
    :cond_1
    iget-object v4, p0, Lcom/facebook/login/widget/LoginButton;->loginText:Ljava/lang/String;

    if-eqz v4, :cond_2

    .line 656
    iget-object v4, p0, Lcom/facebook/login/widget/LoginButton;->loginText:Ljava/lang/String;

    invoke-virtual {p0, v4}, Lcom/facebook/login/widget/LoginButton;->setText(Ljava/lang/CharSequence;)V

    goto :goto_1

    .line 658
    :cond_2
    sget v4, Lcom/facebook/R$string;->com_facebook_loginview_log_in_button_long:I

    invoke-virtual {v1, v4}, Landroid/content/res/Resources;->getString(I)Ljava/lang/String;

    move-result-object v2

    .line 660
    .local v2, "text":Ljava/lang/String;
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getWidth()I

    move-result v3

    .line 662
    .local v3, "width":I
    if-eqz v3, :cond_3

    .line 664
    invoke-direct {p0, v2}, Lcom/facebook/login/widget/LoginButton;->measureButtonWidth(Ljava/lang/String;)I

    move-result v0

    .line 665
    .local v0, "measuredWidth":I
    if-le v0, v3, :cond_3

    .line 667
    sget v4, Lcom/facebook/R$string;->com_facebook_loginview_log_in_button:I

    invoke-virtual {v1, v4}, Landroid/content/res/Resources;->getString(I)Ljava/lang/String;

    move-result-object v2

    .line 670
    .end local v0    # "measuredWidth":I
    :cond_3
    invoke-virtual {p0, v2}, Lcom/facebook/login/widget/LoginButton;->setText(Ljava/lang/CharSequence;)V

    goto :goto_1
.end method

.method private showToolTipPerSettings(Lcom/facebook/internal/Utility$FetchedAppSettings;)V
    .locals 2
    .param p1, "settings"    # Lcom/facebook/internal/Utility$FetchedAppSettings;

    .prologue
    .line 470
    if-eqz p1, :cond_0

    invoke-virtual {p1}, Lcom/facebook/internal/Utility$FetchedAppSettings;->getNuxEnabled()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getVisibility()I

    move-result v1

    if-nez v1, :cond_0

    .line 471
    invoke-virtual {p1}, Lcom/facebook/internal/Utility$FetchedAppSettings;->getNuxContent()Ljava/lang/String;

    move-result-object v0

    .line 472
    .local v0, "toolTipString":Ljava/lang/String;
    invoke-direct {p0, v0}, Lcom/facebook/login/widget/LoginButton;->displayToolTip(Ljava/lang/String;)V

    .line 474
    .end local v0    # "toolTipString":Ljava/lang/String;
    :cond_0
    return-void
.end method


# virtual methods
.method public clearPermissions()V
    .locals 1

    .prologue
    .line 347
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-virtual {v0}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->clearPermissions()V

    .line 348
    return-void
.end method

.method protected configureButton(Landroid/content/Context;Landroid/util/AttributeSet;II)V
    .locals 2
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "attrs"    # Landroid/util/AttributeSet;
    .param p3, "defStyleAttr"    # I
    .param p4, "defStyleRes"    # I

    .prologue
    .line 550
    invoke-super {p0, p1, p2, p3, p4}, Lcom/facebook/FacebookButtonBase;->configureButton(Landroid/content/Context;Landroid/util/AttributeSet;II)V

    .line 551
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getNewLoginClickListener()Lcom/facebook/login/widget/LoginButton$LoginClickListener;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/facebook/login/widget/LoginButton;->setInternalOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 553
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/facebook/login/widget/LoginButton;->parseLoginButtonAttributes(Landroid/content/Context;Landroid/util/AttributeSet;II)V

    .line 555
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->isInEditMode()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 558
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getResources()Landroid/content/res/Resources;

    move-result-object v0

    sget v1, Lcom/facebook/R$color;->com_facebook_blue:I

    invoke-virtual {v0, v1}, Landroid/content/res/Resources;->getColor(I)I

    move-result v0

    invoke-virtual {p0, v0}, Lcom/facebook/login/widget/LoginButton;->setBackgroundColor(I)V

    .line 561
    const-string v0, "Log in with Facebook"

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->loginText:Ljava/lang/String;

    .line 573
    :goto_0
    invoke-direct {p0}, Lcom/facebook/login/widget/LoginButton;->setButtonText()V

    .line 574
    return-void

    .line 563
    :cond_0
    new-instance v0, Lcom/facebook/login/widget/LoginButton$2;

    invoke-direct {v0, p0}, Lcom/facebook/login/widget/LoginButton$2;-><init>(Lcom/facebook/login/widget/LoginButton;)V

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->accessTokenTracker:Lcom/facebook/AccessTokenTracker;

    goto :goto_0
.end method

.method public dismissToolTip()V
    .locals 1

    .prologue
    .line 432
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipPopup:Lcom/facebook/login/widget/ToolTipPopup;

    if-eqz v0, :cond_0

    .line 433
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipPopup:Lcom/facebook/login/widget/ToolTipPopup;

    invoke-virtual {v0}, Lcom/facebook/login/widget/ToolTipPopup;->dismiss()V

    .line 434
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipPopup:Lcom/facebook/login/widget/ToolTipPopup;

    .line 436
    :cond_0
    return-void
.end method

.method public getDefaultAudience()Lcom/facebook/login/DefaultAudience;
    .locals 1

    .prologue
    .line 244
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-virtual {v0}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->getDefaultAudience()Lcom/facebook/login/DefaultAudience;

    move-result-object v0

    return-object v0
.end method

.method protected getDefaultRequestCode()I
    .locals 1

    .prologue
    .line 677
    sget-object v0, Lcom/facebook/internal/CallbackManagerImpl$RequestCodeOffset;->Login:Lcom/facebook/internal/CallbackManagerImpl$RequestCodeOffset;

    invoke-virtual {v0}, Lcom/facebook/internal/CallbackManagerImpl$RequestCodeOffset;->toRequestCode()I

    move-result v0

    return v0
.end method

.method protected getDefaultStyleResource()I
    .locals 1

    .prologue
    .line 582
    sget v0, Lcom/facebook/R$style;->com_facebook_loginview_default_style:I

    return v0
.end method

.method public getLoginBehavior()Lcom/facebook/login/LoginBehavior;
    .locals 1

    .prologue
    .line 373
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-virtual {v0}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->getLoginBehavior()Lcom/facebook/login/LoginBehavior;

    move-result-object v0

    return-object v0
.end method

.method getLoginManager()Lcom/facebook/login/LoginManager;
    .locals 1

    .prologue
    .line 681
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->loginManager:Lcom/facebook/login/LoginManager;

    if-nez v0, :cond_0

    .line 682
    invoke-static {}, Lcom/facebook/login/LoginManager;->getInstance()Lcom/facebook/login/LoginManager;

    move-result-object v0

    iput-object v0, p0, Lcom/facebook/login/widget/LoginButton;->loginManager:Lcom/facebook/login/LoginManager;

    .line 684
    :cond_0
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->loginManager:Lcom/facebook/login/LoginManager;

    return-object v0
.end method

.method protected getNewLoginClickListener()Lcom/facebook/login/widget/LoginButton$LoginClickListener;
    .locals 1

    .prologue
    .line 577
    new-instance v0, Lcom/facebook/login/widget/LoginButton$LoginClickListener;

    invoke-direct {v0, p0}, Lcom/facebook/login/widget/LoginButton$LoginClickListener;-><init>(Lcom/facebook/login/widget/LoginButton;)V

    return-object v0
.end method

.method getPermissions()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 537
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-virtual {v0}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->getPermissions()Ljava/util/List;

    move-result-object v0

    return-object v0
.end method

.method public getToolTipDisplayTime()J
    .locals 2

    .prologue
    .line 425
    iget-wide v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipDisplayTime:J

    return-wide v0
.end method

.method public getToolTipMode()Lcom/facebook/login/widget/LoginButton$ToolTipMode;
    .locals 1

    .prologue
    .line 403
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipMode:Lcom/facebook/login/widget/LoginButton$ToolTipMode;

    return-object v0
.end method

.method protected onAttachedToWindow()V
    .locals 1

    .prologue
    .line 452
    invoke-super {p0}, Lcom/facebook/FacebookButtonBase;->onAttachedToWindow()V

    .line 453
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->accessTokenTracker:Lcom/facebook/AccessTokenTracker;

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->accessTokenTracker:Lcom/facebook/AccessTokenTracker;

    invoke-virtual {v0}, Lcom/facebook/AccessTokenTracker;->isTracking()Z

    move-result v0

    if-nez v0, :cond_0

    .line 454
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->accessTokenTracker:Lcom/facebook/AccessTokenTracker;

    invoke-virtual {v0}, Lcom/facebook/AccessTokenTracker;->startTracking()V

    .line 455
    invoke-direct {p0}, Lcom/facebook/login/widget/LoginButton;->setButtonText()V

    .line 457
    :cond_0
    return-void
.end method

.method protected onDetachedFromWindow()V
    .locals 1

    .prologue
    .line 519
    invoke-super {p0}, Lcom/facebook/FacebookButtonBase;->onDetachedFromWindow()V

    .line 520
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->accessTokenTracker:Lcom/facebook/AccessTokenTracker;

    if-eqz v0, :cond_0

    .line 521
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->accessTokenTracker:Lcom/facebook/AccessTokenTracker;

    invoke-virtual {v0}, Lcom/facebook/AccessTokenTracker;->stopTracking()V

    .line 523
    :cond_0
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->dismissToolTip()V

    .line 524
    return-void
.end method

.method protected onDraw(Landroid/graphics/Canvas;)V
    .locals 1
    .param p1, "canvas"    # Landroid/graphics/Canvas;

    .prologue
    .line 461
    invoke-super {p0, p1}, Lcom/facebook/FacebookButtonBase;->onDraw(Landroid/graphics/Canvas;)V

    .line 463
    iget-boolean v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipChecked:Z

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->isInEditMode()Z

    move-result v0

    if-nez v0, :cond_0

    .line 464
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/facebook/login/widget/LoginButton;->toolTipChecked:Z

    .line 465
    invoke-direct {p0}, Lcom/facebook/login/widget/LoginButton;->checkToolTipSettings()V

    .line 467
    :cond_0
    return-void
.end method

.method protected onLayout(ZIIII)V
    .locals 0
    .param p1, "changed"    # Z
    .param p2, "left"    # I
    .param p3, "top"    # I
    .param p4, "right"    # I
    .param p5, "bottom"    # I

    .prologue
    .line 513
    invoke-super/range {p0 .. p5}, Lcom/facebook/FacebookButtonBase;->onLayout(ZIIII)V

    .line 514
    invoke-direct {p0}, Lcom/facebook/login/widget/LoginButton;->setButtonText()V

    .line 515
    return-void
.end method

.method protected onMeasure(II)V
    .locals 10
    .param p1, "widthMeasureSpec"    # I
    .param p2, "heightMeasureSpec"    # I

    .prologue
    .line 610
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getPaint()Landroid/text/TextPaint;

    move-result-object v7

    invoke-virtual {v7}, Landroid/text/TextPaint;->getFontMetrics()Landroid/graphics/Paint$FontMetrics;

    move-result-object v0

    .line 611
    .local v0, "fontMetrics":Landroid/graphics/Paint$FontMetrics;
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getCompoundPaddingTop()I

    move-result v7

    iget v8, v0, Landroid/graphics/Paint$FontMetrics;->top:F

    .line 612
    invoke-static {v8}, Ljava/lang/Math;->abs(F)F

    move-result v8

    iget v9, v0, Landroid/graphics/Paint$FontMetrics;->bottom:F

    invoke-static {v9}, Ljava/lang/Math;->abs(F)F

    move-result v9

    add-float/2addr v8, v9

    float-to-double v8, v8

    invoke-static {v8, v9}, Ljava/lang/Math;->ceil(D)D

    move-result-wide v8

    double-to-int v8, v8

    add-int/2addr v7, v8

    .line 613
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getCompoundPaddingBottom()I

    move-result v8

    add-int v1, v7, v8

    .line 615
    .local v1, "height":I
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getResources()Landroid/content/res/Resources;

    move-result-object v4

    .line 616
    .local v4, "resources":Landroid/content/res/Resources;
    iget-object v5, p0, Lcom/facebook/login/widget/LoginButton;->loginText:Ljava/lang/String;

    .line 619
    .local v5, "text":Ljava/lang/String;
    if-nez v5, :cond_0

    .line 620
    sget v7, Lcom/facebook/R$string;->com_facebook_loginview_log_in_button_long:I

    invoke-virtual {v4, v7}, Landroid/content/res/Resources;->getString(I)Ljava/lang/String;

    move-result-object v5

    .line 621
    invoke-direct {p0, v5}, Lcom/facebook/login/widget/LoginButton;->measureButtonWidth(Ljava/lang/String;)I

    move-result v2

    .line 622
    .local v2, "logInWidth":I
    invoke-static {v2, p1}, Lcom/facebook/login/widget/LoginButton;->resolveSize(II)I

    move-result v6

    .line 623
    .local v6, "width":I
    if-ge v6, v2, :cond_0

    .line 624
    sget v7, Lcom/facebook/R$string;->com_facebook_loginview_log_in_button:I

    invoke-virtual {v4, v7}, Landroid/content/res/Resources;->getString(I)Ljava/lang/String;

    move-result-object v5

    .line 627
    .end local v2    # "logInWidth":I
    .end local v6    # "width":I
    :cond_0
    invoke-direct {p0, v5}, Lcom/facebook/login/widget/LoginButton;->measureButtonWidth(Ljava/lang/String;)I

    move-result v2

    .line 629
    .restart local v2    # "logInWidth":I
    iget-object v5, p0, Lcom/facebook/login/widget/LoginButton;->logoutText:Ljava/lang/String;

    .line 630
    if-nez v5, :cond_1

    .line 631
    sget v7, Lcom/facebook/R$string;->com_facebook_loginview_log_out_button:I

    invoke-virtual {v4, v7}, Landroid/content/res/Resources;->getString(I)Ljava/lang/String;

    move-result-object v5

    .line 633
    :cond_1
    invoke-direct {p0, v5}, Lcom/facebook/login/widget/LoginButton;->measureButtonWidth(Ljava/lang/String;)I

    move-result v3

    .line 635
    .local v3, "logOutWidth":I
    invoke-static {v2, v3}, Ljava/lang/Math;->max(II)I

    move-result v7

    invoke-static {v7, p1}, Lcom/facebook/login/widget/LoginButton;->resolveSize(II)I

    move-result v6

    .line 636
    .restart local v6    # "width":I
    invoke-virtual {p0, v6, v1}, Lcom/facebook/login/widget/LoginButton;->setMeasuredDimension(II)V

    .line 637
    return-void
.end method

.method protected onVisibilityChanged(Landroid/view/View;I)V
    .locals 0
    .param p1, "changedView"    # Landroid/view/View;
    .param p2, "visibility"    # I

    .prologue
    .line 528
    invoke-super {p0, p1, p2}, Lcom/facebook/FacebookButtonBase;->onVisibilityChanged(Landroid/view/View;I)V

    .line 530
    if-eqz p2, :cond_0

    .line 531
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->dismissToolTip()V

    .line 533
    :cond_0
    return-void
.end method

.method public registerCallback(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V
    .locals 1
    .param p1, "callbackManager"    # Lcom/facebook/CallbackManager;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/facebook/CallbackManager;",
            "Lcom/facebook/FacebookCallback",
            "<",
            "Lcom/facebook/login/LoginResult;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 447
    .local p2, "callback":Lcom/facebook/FacebookCallback;, "Lcom/facebook/FacebookCallback<Lcom/facebook/login/LoginResult;>;"
    invoke-virtual {p0}, Lcom/facebook/login/widget/LoginButton;->getLoginManager()Lcom/facebook/login/LoginManager;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/facebook/login/LoginManager;->registerCallback(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V

    .line 448
    return-void
.end method

.method public setDefaultAudience(Lcom/facebook/login/DefaultAudience;)V
    .locals 1
    .param p1, "defaultAudience"    # Lcom/facebook/login/DefaultAudience;

    .prologue
    .line 233
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-virtual {v0, p1}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->setDefaultAudience(Lcom/facebook/login/DefaultAudience;)V

    .line 234
    return-void
.end method

.method public setLoginBehavior(Lcom/facebook/login/LoginBehavior;)V
    .locals 1
    .param p1, "loginBehavior"    # Lcom/facebook/login/LoginBehavior;

    .prologue
    .line 360
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-virtual {v0, p1}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->setLoginBehavior(Lcom/facebook/login/LoginBehavior;)V

    .line 361
    return-void
.end method

.method setLoginManager(Lcom/facebook/login/LoginManager;)V
    .locals 0
    .param p1, "loginManager"    # Lcom/facebook/login/LoginManager;

    .prologue
    .line 688
    iput-object p1, p0, Lcom/facebook/login/widget/LoginButton;->loginManager:Lcom/facebook/login/LoginManager;

    .line 689
    return-void
.end method

.method setProperties(Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;)V
    .locals 0
    .param p1, "properties"    # Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    .prologue
    .line 541
    iput-object p1, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    .line 542
    return-void
.end method

.method public setPublishPermissions(Ljava/util/List;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 315
    .local p1, "permissions":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-virtual {v0, p1}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->setPublishPermissions(Ljava/util/List;)V

    .line 316
    return-void
.end method

.method public varargs setPublishPermissions([Ljava/lang/String;)V
    .locals 2
    .param p1, "permissions"    # [Ljava/lang/String;

    .prologue
    .line 339
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-static {p1}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->setPublishPermissions(Ljava/util/List;)V

    .line 340
    return-void
.end method

.method public setReadPermissions(Ljava/util/List;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 267
    .local p1, "permissions":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-virtual {v0, p1}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->setReadPermissions(Ljava/util/List;)V

    .line 268
    return-void
.end method

.method public varargs setReadPermissions([Ljava/lang/String;)V
    .locals 2
    .param p1, "permissions"    # [Ljava/lang/String;

    .prologue
    .line 290
    iget-object v0, p0, Lcom/facebook/login/widget/LoginButton;->properties:Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;

    invoke-static {p1}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/facebook/login/widget/LoginButton$LoginButtonProperties;->setReadPermissions(Ljava/util/List;)V

    .line 291
    return-void
.end method

.method public setToolTipDisplayTime(J)V
    .locals 1
    .param p1, "displayTime"    # J

    .prologue
    .line 416
    iput-wide p1, p0, Lcom/facebook/login/widget/LoginButton;->toolTipDisplayTime:J

    .line 417
    return-void
.end method

.method public setToolTipMode(Lcom/facebook/login/widget/LoginButton$ToolTipMode;)V
    .locals 0
    .param p1, "toolTipMode"    # Lcom/facebook/login/widget/LoginButton$ToolTipMode;

    .prologue
    .line 394
    iput-object p1, p0, Lcom/facebook/login/widget/LoginButton;->toolTipMode:Lcom/facebook/login/widget/LoginButton$ToolTipMode;

    .line 395
    return-void
.end method

.method public setToolTipStyle(Lcom/facebook/login/widget/ToolTipPopup$Style;)V
    .locals 0
    .param p1, "toolTipStyle"    # Lcom/facebook/login/widget/ToolTipPopup$Style;

    .prologue
    .line 383
    iput-object p1, p0, Lcom/facebook/login/widget/LoginButton;->toolTipStyle:Lcom/facebook/login/widget/ToolTipPopup$Style;

    .line 384
    return-void
.end method
