.class public Lcom/igg/iggsdkbusiness/InputActivity;
.super Ljava/lang/Object;
.source "InputActivity.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/InputActivity;


# instance fields
.field InputStrCallBack:Ljava/lang/String;

.field btn:Landroid/widget/Button;

.field build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

.field dialog:Landroid/app/Dialog;

.field ed:Landroid/widget/EditText;

.field layoutParams:Landroid/widget/LinearLayout$LayoutParams;

.field layoutParams1:Landroid/widget/LinearLayout$LayoutParams;

.field layoutParams2:Landroid/widget/LinearLayout$LayoutParams;

.field linearLayout:Landroid/widget/LinearLayout;

.field linearLayout1:Landroid/widget/LinearLayout;

.field linearLayout2:Landroid/widget/LinearLayout;


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 49
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 47
    const-string v0, "InputStrCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity;->InputStrCallBack:Ljava/lang/String;

    .line 49
    return-void
.end method

.method private CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 359
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 360
    return-void
.end method

.method private ShowDiaog([I)V
    .locals 10
    .param p1, "unicode"    # [I

    .prologue
    .line 147
    :try_start_0
    const-string v5, "InputActivity"

    const-string v6, "ShowDiaog"

    invoke-static {v5, v6}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 149
    new-instance v5, Landroid/app/Dialog;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/app/Dialog;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->dialog:Landroid/app/Dialog;

    .line 151
    new-instance v5, Landroid/widget/LinearLayout;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    .line 152
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    const v6, -0xffff01

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setBackgroundColor(I)V

    .line 153
    new-instance v5, Landroid/widget/LinearLayout$LayoutParams;

    const/4 v6, -0x1

    const/4 v7, -0x1

    invoke-direct {v5, v6, v7}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    .line 154
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 155
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    const/4 v6, 0x1

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setOrientation(I)V

    .line 156
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    const/16 v6, 0x50

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setGravity(I)V

    .line 157
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    const/high16 v6, 0x3f800000    # 1.0f

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setWeightSum(F)V

    .line 159
    new-instance v5, Landroid/widget/LinearLayout;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    .line 160
    new-instance v5, Landroid/widget/LinearLayout$LayoutParams;

    const/4 v6, -0x1

    const/4 v7, -0x1

    invoke-direct {v5, v6, v7}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams2:Landroid/widget/LinearLayout$LayoutParams;

    .line 161
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams2:Landroid/widget/LinearLayout$LayoutParams;

    const v6, 0x3e4ccccd    # 0.2f

    iput v6, v5, Landroid/widget/LinearLayout$LayoutParams;->weight:F

    .line 162
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    const v6, -0xff0100

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setBackgroundColor(I)V

    .line 163
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams2:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 164
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    const/4 v6, 0x0

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setOrientation(I)V

    .line 166
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    const/high16 v6, 0x3f800000    # 1.0f

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setWeightSum(F)V

    .line 168
    new-instance v5, Landroid/widget/EditText;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/widget/EditText;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    .line 169
    new-instance v5, Landroid/widget/LinearLayout$LayoutParams;

    const/4 v6, 0x0

    const/4 v7, -0x1

    invoke-direct {v5, v6, v7}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    .line 170
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    const/16 v6, 0x50

    iput v6, v5, Landroid/widget/LinearLayout$LayoutParams;->gravity:I

    .line 171
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    const v6, 0x3f666666    # 0.9f

    iput v6, v5, Landroid/widget/LinearLayout$LayoutParams;->weight:F

    .line 172
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 173
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    const/16 v6, 0x13

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setGravity(I)V

    .line 174
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 175
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-static {p1}, Lcom/igg/iggsdkbusiness/InputActivity;->getEmojiStringByUnicode([I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setText(Ljava/lang/CharSequence;)V

    .line 176
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->selectAll()V

    .line 177
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    new-instance v6, Lcom/igg/iggsdkbusiness/InputActivity$1;

    invoke-direct {v6, p0}, Lcom/igg/iggsdkbusiness/InputActivity$1;-><init>(Lcom/igg/iggsdkbusiness/InputActivity;)V

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setOnKeyListener(Landroid/view/View$OnKeyListener;)V

    .line 187
    new-instance v5, Landroid/widget/Button;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/widget/Button;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    .line 188
    new-instance v5, Landroid/widget/LinearLayout$LayoutParams;

    const/4 v6, 0x0

    const/4 v7, -0x1

    invoke-direct {v5, v6, v7}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    .line 189
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    const/16 v6, 0x50

    iput v6, v5, Landroid/widget/LinearLayout$LayoutParams;->gravity:I

    .line 190
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    const v6, 0x3dcccccd    # 0.1f

    iput v6, v5, Landroid/widget/LinearLayout$LayoutParams;->weight:F

    .line 191
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 192
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    const/4 v6, 0x1

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setGravity(I)V

    .line 193
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 194
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    const-string v6, "\u78ba\u5b9a"

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setText(Ljava/lang/CharSequence;)V

    .line 195
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    new-instance v6, Lcom/igg/iggsdkbusiness/InputActivity$2;

    invoke-direct {v6, p0}, Lcom/igg/iggsdkbusiness/InputActivity$2;-><init>(Lcom/igg/iggsdkbusiness/InputActivity;)V

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 209
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 211
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->dialog:Landroid/app/Dialog;

    const/4 v6, 0x1

    invoke-virtual {v5, v6}, Landroid/app/Dialog;->setCancelable(Z)V

    .line 214
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->dialog:Landroid/app/Dialog;

    invoke-virtual {v5}, Landroid/app/Dialog;->getWindow()Landroid/view/Window;

    move-result-object v1

    .line 215
    .local v1, "dialogWindow":Landroid/view/Window;
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v5

    invoke-virtual {v5}, Landroid/app/Activity;->getWindowManager()Landroid/view/WindowManager;

    move-result-object v3

    .line 216
    .local v3, "m":Landroid/view/WindowManager;
    invoke-interface {v3}, Landroid/view/WindowManager;->getDefaultDisplay()Landroid/view/Display;

    move-result-object v0

    .line 217
    .local v0, "d":Landroid/view/Display;
    invoke-virtual {v1}, Landroid/view/Window;->getAttributes()Landroid/view/WindowManager$LayoutParams;

    move-result-object v4

    .line 218
    .local v4, "p":Landroid/view/WindowManager$LayoutParams;
    invoke-virtual {v0}, Landroid/view/Display;->getHeight()I

    move-result v5

    int-to-double v6, v5

    const-wide v8, 0x3fe3333333333333L    # 0.6

    mul-double/2addr v6, v8

    double-to-int v5, v6

    iput v5, v4, Landroid/view/WindowManager$LayoutParams;->height:I

    .line 219
    invoke-virtual {v0}, Landroid/view/Display;->getWidth()I

    move-result v5

    int-to-double v6, v5

    const-wide v8, 0x3fe4cccccccccccdL    # 0.65

    mul-double/2addr v6, v8

    double-to-int v5, v6

    iput v5, v4, Landroid/view/WindowManager$LayoutParams;->width:I

    .line 220
    const/16 v5, 0x50

    iput v5, v4, Landroid/view/WindowManager$LayoutParams;->gravity:I

    .line 221
    invoke-virtual {v1, v4}, Landroid/view/Window;->setAttributes(Landroid/view/WindowManager$LayoutParams;)V

    .line 223
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->dialog:Landroid/app/Dialog;

    invoke-virtual {v5}, Landroid/app/Dialog;->show()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 228
    .end local v0    # "d":Landroid/view/Display;
    .end local v1    # "dialogWindow":Landroid/view/Window;
    .end local v3    # "m":Landroid/view/WindowManager;
    .end local v4    # "p":Landroid/view/WindowManager$LayoutParams;
    :goto_0
    return-void

    .line 225
    :catch_0
    move-exception v2

    .line 226
    .local v2, "e":Ljava/lang/Exception;
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/InputActivity;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/InputActivity;
    .param p1, "x1"    # Ljava/lang/String;
    .param p2, "x2"    # Ljava/lang/String;

    .prologue
    .line 36
    invoke-direct {p0, p1, p2}, Lcom/igg/iggsdkbusiness/InputActivity;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method private getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 363
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method private static getEmojiStringByUnicode([I)Ljava/lang/String;
    .locals 4
    .param p0, "unicode"    # [I

    .prologue
    .line 348
    const-string v2, ""

    .line 349
    .local v2, "str":Ljava/lang/String;
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    .line 351
    .local v1, "sb":Ljava/lang/StringBuilder;
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    array-length v3, p0

    if-ge v0, v3, :cond_0

    .line 352
    aget v3, p0, v0

    invoke-static {v3}, Ljava/lang/Character;->toChars(I)[C

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append([C)Ljava/lang/StringBuilder;

    .line 351
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 354
    :cond_0
    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    return-object v3
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/InputActivity;
    .locals 1

    .prologue
    .line 52
    sget-object v0, Lcom/igg/iggsdkbusiness/InputActivity;->instance:Lcom/igg/iggsdkbusiness/InputActivity;

    if-nez v0, :cond_0

    .line 53
    new-instance v0, Lcom/igg/iggsdkbusiness/InputActivity;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/InputActivity;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/InputActivity;->instance:Lcom/igg/iggsdkbusiness/InputActivity;

    .line 55
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/InputActivity;->instance:Lcom/igg/iggsdkbusiness/InputActivity;

    return-object v0
.end method


# virtual methods
.method public Open([I)V
    .locals 3
    .param p1, "unicode"    # [I

    .prologue
    .line 59
    const-string v1, "InputActivity"

    const-string v2, "Open"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 135
    :try_start_0
    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/InputActivity;->ShowAlertDialog([I)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 142
    :goto_0
    return-void

    .line 137
    :catch_0
    move-exception v0

    .line 139
    .local v0, "e":Ljava/lang/Exception;
    const-string v1, "InputActivity"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method

.method SetSoftKeyborad(ZLandroid/view/View;J)V
    .locals 3
    .param p1, "hasFocus"    # Z
    .param p2, "view"    # Landroid/view/View;
    .param p3, "delayMillis"    # J

    .prologue
    .line 332
    if-eqz p1, :cond_0

    .line 333
    :try_start_0
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v1

    invoke-virtual {v1}, Landroid/app/Activity;->getWindow()Landroid/view/Window;

    move-result-object v1

    invoke-virtual {v1}, Landroid/view/Window;->getDecorView()Landroid/view/View;

    move-result-object v1

    new-instance v2, Lcom/igg/iggsdkbusiness/InputActivity$6;

    invoke-direct {v2, p0, p2}, Lcom/igg/iggsdkbusiness/InputActivity$6;-><init>(Lcom/igg/iggsdkbusiness/InputActivity;Landroid/view/View;)V

    invoke-virtual {v1, v2, p3, p4}, Landroid/view/View;->postDelayed(Ljava/lang/Runnable;J)Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 345
    :cond_0
    :goto_0
    return-void

    .line 342
    :catch_0
    move-exception v0

    .line 343
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method ShowAlertDialog([I)V
    .locals 12
    .param p1, "unicode"    # [I

    .prologue
    const/4 v11, 0x1

    const/high16 v10, 0x3f800000    # 1.0f

    const/16 v9, 0x50

    const/4 v8, 0x0

    const/4 v7, -0x1

    .line 231
    new-instance v5, Landroid/widget/LinearLayout;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    .line 233
    new-instance v5, Landroid/widget/LinearLayout$LayoutParams;

    invoke-direct {v5, v7, v7}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    .line 234
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 235
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v11}, Landroid/widget/LinearLayout;->setOrientation(I)V

    .line 236
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v9}, Landroid/widget/LinearLayout;->setGravity(I)V

    .line 237
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v10}, Landroid/widget/LinearLayout;->setWeightSum(F)V

    .line 239
    new-instance v5, Landroid/widget/LinearLayout;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    .line 240
    new-instance v5, Landroid/widget/LinearLayout$LayoutParams;

    invoke-direct {v5, v7, v7}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams2:Landroid/widget/LinearLayout$LayoutParams;

    .line 241
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams2:Landroid/widget/LinearLayout$LayoutParams;

    const v6, 0x3e4ccccd    # 0.2f

    iput v6, v5, Landroid/widget/LinearLayout$LayoutParams;->weight:F

    .line 243
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams2:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 244
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v8}, Landroid/widget/LinearLayout;->setOrientation(I)V

    .line 246
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v10}, Landroid/widget/LinearLayout;->setWeightSum(F)V

    .line 247
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v8}, Landroid/widget/LinearLayout;->setBackgroundColor(I)V

    .line 249
    new-instance v5, Landroid/widget/EditText;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/widget/EditText;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    .line 250
    new-instance v5, Landroid/widget/LinearLayout$LayoutParams;

    invoke-direct {v5, v8, v7}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    .line 251
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    iput v9, v5, Landroid/widget/LinearLayout$LayoutParams;->gravity:I

    .line 252
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    const v6, 0x3f666666    # 0.9f

    iput v6, v5, Landroid/widget/LinearLayout$LayoutParams;->weight:F

    .line 253
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 254
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    const/16 v6, 0x13

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setGravity(I)V

    .line 255
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v5, v11}, Landroid/widget/EditText;->setFocusable(Z)V

    .line 257
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 258
    invoke-static {p1}, Lcom/igg/iggsdkbusiness/InputActivity;->getEmojiStringByUnicode([I)Ljava/lang/String;

    move-result-object v3

    .line 259
    .local v3, "strConttent":Ljava/lang/String;
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v5, v3}, Landroid/widget/EditText;->setText(Ljava/lang/CharSequence;)V

    .line 260
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setSelection(I)V

    .line 261
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->selectAll()V

    .line 262
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    new-instance v6, Lcom/igg/iggsdkbusiness/InputActivity$3;

    invoke-direct {v6, p0}, Lcom/igg/iggsdkbusiness/InputActivity$3;-><init>(Lcom/igg/iggsdkbusiness/InputActivity;)V

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setOnKeyListener(Landroid/view/View$OnKeyListener;)V

    .line 273
    new-instance v5, Landroid/widget/Button;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/widget/Button;-><init>(Landroid/content/Context;)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    .line 274
    new-instance v5, Landroid/widget/LinearLayout$LayoutParams;

    invoke-direct {v5, v8, v7}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    .line 275
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    iput v9, v5, Landroid/widget/LinearLayout$LayoutParams;->gravity:I

    .line 276
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    const v6, 0x3dcccccd    # 0.1f

    iput v6, v5, Landroid/widget/LinearLayout$LayoutParams;->weight:F

    .line 277
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->layoutParams:Landroid/widget/LinearLayout$LayoutParams;

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 278
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    const/16 v6, 0x11

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setGravity(I)V

    .line 279
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    invoke-virtual {v5, v7}, Landroid/widget/Button;->setBackgroundColor(I)V

    .line 280
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 281
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    const-string v6, "\u78ba\u5b9a"

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setText(Ljava/lang/CharSequence;)V

    .line 282
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    new-instance v6, Lcom/igg/iggsdkbusiness/InputActivity$4;

    invoke-direct {v6, p0}, Lcom/igg/iggsdkbusiness/InputActivity$4;-><init>(Lcom/igg/iggsdkbusiness/InputActivity;)V

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 290
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->btn:Landroid/widget/Button;

    const/high16 v6, -0x1000000

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setTextColor(I)V

    .line 291
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout2:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v6}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;)V

    .line 292
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v7}, Landroid/widget/LinearLayout;->setBackgroundColor(I)V

    .line 294
    new-instance v5, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v6

    invoke-direct {v5, v6}, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;-><init>(Landroid/content/Context;)V

    invoke-virtual {v5}, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->create()Lcom/igg/iggsdkbusiness/MyAlertDialog;

    move-result-object v5

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    .line 295
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity;->linearLayout1:Landroid/widget/LinearLayout;

    invoke-virtual {v5, v6}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->setView(Landroid/view/View;)V

    .line 296
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-virtual {v5}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->show()V

    .line 299
    sget v5, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v6, 0x8

    if-le v5, v6, :cond_0

    .line 300
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v5

    invoke-virtual {v5}, Landroid/app/Activity;->getWindowManager()Landroid/view/WindowManager;

    move-result-object v5

    invoke-interface {v5}, Landroid/view/WindowManager;->getDefaultDisplay()Landroid/view/Display;

    move-result-object v5

    invoke-virtual {v5}, Landroid/view/Display;->getWidth()I

    move-result v4

    .line 301
    .local v4, "width":I
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v5

    invoke-virtual {v5}, Landroid/app/Activity;->getWindowManager()Landroid/view/WindowManager;

    move-result-object v5

    invoke-interface {v5}, Landroid/view/WindowManager;->getDefaultDisplay()Landroid/view/Display;

    move-result-object v5

    invoke-virtual {v5}, Landroid/view/Display;->getHeight()I

    move-result v0

    .line 310
    .local v0, "height":I
    :goto_0
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-virtual {v5}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->getWindow()Landroid/view/Window;

    move-result-object v5

    invoke-virtual {v5}, Landroid/view/Window;->getAttributes()Landroid/view/WindowManager$LayoutParams;

    move-result-object v1

    .line 312
    .local v1, "params":Landroid/view/WindowManager$LayoutParams;
    iput v7, v1, Landroid/view/WindowManager$LayoutParams;->width:I

    .line 314
    const/4 v5, -0x2

    iput v5, v1, Landroid/view/WindowManager$LayoutParams;->height:I

    .line 316
    iput v9, v1, Landroid/view/WindowManager$LayoutParams;->gravity:I

    .line 320
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-virtual {v5}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->getWindow()Landroid/view/Window;

    move-result-object v5

    invoke-virtual {v5, v1}, Landroid/view/Window;->setAttributes(Landroid/view/WindowManager$LayoutParams;)V

    .line 323
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    new-instance v6, Lcom/igg/iggsdkbusiness/InputActivity$5;

    invoke-direct {v6, p0}, Lcom/igg/iggsdkbusiness/InputActivity$5;-><init>(Lcom/igg/iggsdkbusiness/InputActivity;)V

    invoke-virtual {v5, v6}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->addOnWindowsFocusChangedListener(Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;)V

    .line 328
    return-void

    .line 303
    .end local v0    # "height":I
    .end local v1    # "params":Landroid/view/WindowManager$LayoutParams;
    .end local v4    # "width":I
    :cond_0
    new-instance v2, Landroid/graphics/Point;

    invoke-direct {v2}, Landroid/graphics/Point;-><init>()V

    .line 304
    .local v2, "point":Landroid/graphics/Point;
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/InputActivity;->getActivity()Landroid/app/Activity;

    move-result-object v5

    invoke-virtual {v5}, Landroid/app/Activity;->getWindowManager()Landroid/view/WindowManager;

    move-result-object v5

    invoke-interface {v5}, Landroid/view/WindowManager;->getDefaultDisplay()Landroid/view/Display;

    move-result-object v5

    invoke-virtual {v5, v2}, Landroid/view/Display;->getSize(Landroid/graphics/Point;)V

    .line 305
    iget v4, v2, Landroid/graphics/Point;->x:I

    .line 306
    .restart local v4    # "width":I
    iget v0, v2, Landroid/graphics/Point;->y:I

    .restart local v0    # "height":I
    goto :goto_0
.end method
