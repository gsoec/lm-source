.class Lcom/igexin/push/extension/distribution/basic/util/webview/b;
.super Lcom/igexin/push/extension/distribution/basic/h/f;


# instance fields
.field a:Ljava/lang/String;

.field h:Ljava/lang/String;

.field i:Ljava/lang/String;

.field j:I


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/igexin/push/extension/distribution/basic/h/f;-><init>(Ljava/lang/String;)V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->h:Ljava/lang/String;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->a:Ljava/lang/String;

    iput-object p3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->i:Ljava/lang/String;

    iput p4, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->j:I

    return-void
.end method


# virtual methods
.method public a([B)V
    .locals 2

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->g:Z

    new-instance v0, Ljava/io/FileOutputStream;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->a:Ljava/lang/String;

    invoke-direct {v0, v1}, Ljava/io/FileOutputStream;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, p1}, Ljava/io/FileOutputStream;->write([B)V

    invoke-virtual {v0}, Ljava/io/FileOutputStream;->flush()V

    invoke-virtual {v0}, Ljava/io/FileOutputStream;->close()V

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->g:Z

    return-void
.end method

.method public final b()I
    .locals 1

    const v0, 0x88802

    return v0
.end method
